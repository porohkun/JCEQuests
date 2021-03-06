﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PNetJson;

namespace JCEQuests.Quests
{
    public class Condition
    {
        private static Dictionary<string, int> _operators;
        private static List<string> _unaryMinusPreviewTokens;
        private List<Token> _sequence = new List<Token>();
        static Condition()
        {
            _operators = new Dictionary<string, int>();
            _operators.Add("(", 0);
            _operators.Add(")", 0);
            //_operators.Add("?", 2);
            _operators.Add(":", 2);
            _operators.Add("||", 3);
            _operators.Add("&&", 3);
            _operators.Add("==", 4);
            _operators.Add("!=", 4);
            _operators.Add("<", 5);
            _operators.Add(">", 5);
            _operators.Add("<=", 5);
            _operators.Add(">=", 5);
            _operators.Add("+", 6);
            _operators.Add("-", 6);
            _operators.Add("*", 7);
            _operators.Add("/", 7);
            _operators.Add("^", 8);
            _operators.Add("~", 9);
            _operators.Add("!", 9);
            _unaryMinusPreviewTokens = new List<string>();
            _unaryMinusPreviewTokens.Add("");
            _unaryMinusPreviewTokens.AddRange(_operators.Keys);
            _unaryMinusPreviewTokens.Remove(")");
        }

        protected Condition(bool singleValue)
        {
            _sequence.Add(new Token(singleValue));
        }

        private Condition(IEnumerable<Token> sequence)
        {
            _sequence.AddRange(sequence);
        }

        public virtual bool Check(Quest quest)
        {
            try
            {
                var result = CalculateResult(quest);
                if (result.Type == TokenType.Numeric)
                    throw new QuestException("Число нельзя использовать как булево значение.");
                return result.GetBoolean(quest);
            }
            catch (Exception e)
            {
                throw new QuestException(string.Format("Невозможно вычислить операцию по причине:\r\n- {0}.", e.Message), e);
            }
        }

        public virtual int Calculate(Quest quest)
        {
            try
            {
                var result = CalculateResult(quest);
                if (result.Type == TokenType.Boolean)
                    throw new QuestException("Булево значение нельзя использовать как число.");
                return result.GetNumber(quest);
            }
            catch (Exception e)
            {
                throw new QuestException(string.Format("Невозможно вычислить операцию по причине:\r\n- {0}.", e.Message), e);
            }
        }

        private Token CalculateResult(Quest quest)
        {
            Stack<Token> stack = new Stack<Token>();

            foreach (var item in _sequence)
            {
                if (item.Type == TokenType.Operator)
                {
                    var op2 = stack.Pop();

                    switch (item.Operator)
                    {
                        case OperatorType.NOT:
                            if (op2.Type == TokenType.Boolean) stack.Push(new Token(!op2.GetBoolean(quest)));
                            else throw new QuestException("Неверно составлена формула.");
                            continue;
                        case OperatorType.UnaryMinus:
                            if (op2.Type == TokenType.Numeric) stack.Push(new Token(-op2.GetNumber(quest)));
                            else throw new QuestException("Неверно составлена формула.");
                            continue;
                    }
                    var op1 = stack.Pop();

                    if (item.Operator== OperatorType.Ternar)
                    {
                        var op0 = stack.Pop();
                        if (op0.Type != TokenType.Boolean)
                            throw new QuestException("Неверно составлена формула.");
                        if (op1.Type == TokenType.Boolean && op2.Type == TokenType.Boolean)
                            stack.Push(new Token(op0.GetBoolean(quest) ? op1.GetBoolean(quest) : op2.GetBoolean(quest)));
                        else if (op1.Type == TokenType.Numeric && op2.Type == TokenType.Numeric)
                            stack.Push(new Token(op0.GetBoolean(quest) ? op1.GetNumber(quest) : op2.GetNumber(quest)));
                        else throw new QuestException("Неверно составлена формула.");
                        continue;
                    }

                    if (op1.Type == TokenType.Boolean && op2.Type == TokenType.Boolean)
                        switch (item.Operator)
                        {
                            case OperatorType.OR:
                                stack.Push(new Token(op1.GetBoolean(quest) || op2.GetBoolean(quest))); continue;
                            case OperatorType.AND:
                                stack.Push(new Token(op1.GetBoolean(quest) && op2.GetBoolean(quest))); continue;
                            case OperatorType.Equal:
                                stack.Push(new Token(op1.GetBoolean(quest) == op2.GetBoolean(quest))); continue;
                            case OperatorType.NotEqual:
                                stack.Push(new Token(op1.GetBoolean(quest) != op2.GetBoolean(quest))); continue;
                            default:
                                throw new QuestException("Неверно составлена формула.");
                        }
                    else if (op1.Type == TokenType.Numeric && op2.Type == TokenType.Numeric)
                        switch (item.Operator)
                        {
                            case OperatorType.Less:
                                stack.Push(new Token(op1.GetNumber(quest) < op2.GetNumber(quest))); continue;
                            case OperatorType.More:
                                stack.Push(new Token(op1.GetNumber(quest) > op2.GetNumber(quest))); continue;
                            case OperatorType.LessOrEqual:
                                stack.Push(new Token(op1.GetNumber(quest) <= op2.GetNumber(quest))); continue;
                            case OperatorType.MoreOrEqual:
                                stack.Push(new Token(op1.GetNumber(quest) >= op2.GetNumber(quest))); continue;
                            case OperatorType.Plus:
                                stack.Push(new Token(op1.GetNumber(quest) + op2.GetNumber(quest))); continue;
                            case OperatorType.Minus:
                                stack.Push(new Token(op1.GetNumber(quest) - op2.GetNumber(quest))); continue;
                            case OperatorType.Multiply:
                                stack.Push(new Token(op1.GetNumber(quest) * op2.GetNumber(quest))); continue;
                            case OperatorType.Divide:
                                stack.Push(new Token(op1.GetNumber(quest) / op2.GetNumber(quest))); continue;
                            case OperatorType.Power:
                                stack.Push(new Token((int)Math.Pow(op1.GetNumber(quest), op2.GetNumber(quest)))); continue;
                            case OperatorType.Equal:
                                stack.Push(new Token(op1.GetNumber(quest) == op2.GetNumber(quest))); continue;
                            case OperatorType.NotEqual:
                                stack.Push(new Token(op1.GetNumber(quest) != op2.GetNumber(quest))); continue;
                            default:
                                throw new QuestException("Неверно составлена формула.");
                        }
                    throw new QuestException("Неверно составлена формула.");
                }
                else
                    stack.Push(item);
            }
            return stack.Pop();
        }

        public static Condition Create(JSONValue json)
        {
            if (json == null) return new Condition(true);

            var tokens = Parse(json);

            return new Condition(ConvertToPostfix(tokens));
        }

        private static IEnumerable<Token> ConvertToPostfix(IEnumerable<string> tokens)
        {
            var temp = new Stack<string>();
            string preview = "";

            foreach (string tkn in tokens)
            {
                string token = tkn;
                if (token == "-" && _unaryMinusPreviewTokens.Contains(preview))
                    token = "~";

                if (IsOperator(token))
                {
                    if (temp.Count > 0 && !token.Equals("("))
                    {
                        if (token.Equals(")"))
                        {
                            string s = temp.Pop();
                            while (s != "(")
                            {
                                yield return new Token(s);
                                s = temp.Pop();
                            }
                        }
                        else if (GetPriority(token) > GetPriority(temp.Peek()))
                            temp.Push(token);
                        else
                        {
                            while (temp.Count > 0 && GetPriority(token) <= GetPriority(temp.Peek()))
                                yield return new Token(temp.Pop());
                            temp.Push(token);
                        }
                    }
                    else
                        temp.Push(token);
                }
                else
                    yield return new Token(token);
                preview = token;
            }
            if (temp.Count > 0)
                foreach (string c in temp)
                    yield return new Token(c);
        }

        private static bool IsOperator(string token)
        {
            return _operators.ContainsKey(token);
        }

        private static int GetPriority(string token)
        {
            return _operators[token];
        }

        private static IEnumerable<string> Parse(string input)
        {
            return Regex.Matches(input, @"[\w.]+|\)|\(|\+|\-|\*|\/|\<\=|\>\=|\<|\>|\=\=|\!\=|\&\&|\|\||\?|\:|\!")
               .Cast<Match>()
               .Select(match => match.Value)
               .Where(val => !val.Equals("?"));
        }

        private struct Token
        {
            internal TokenType Type;
            internal OperatorType Operator;

            private int _number;
            private bool _boolean;
            private string _operand;
            private bool _virtual;

            internal int GetNumber(Quest quest)
            {
                if (_virtual)
                {
                    var item = _operand.Split('.');
                    return quest.ItemCount(item[0], item[1]);
                }
                else
                    return _number;
            }

            internal bool GetBoolean(Quest quest)
            {
                if (_virtual)
                    return quest.GetMarks().Contains(_operand);
                else
                    return _boolean;
            }

            internal Token(string t)
            {
                _number = 0;
                _boolean = false;
                _operand = "";
                _virtual = false;
                Operator = OperatorType.AND;
                switch (t)
                {
                    case ":": Type = TokenType.Operator; Operator = OperatorType.Ternar; return;
                    case "||": Type = TokenType.Operator; Operator = OperatorType.OR; return;
                    case "&&": Type = TokenType.Operator; Operator = OperatorType.AND; return;
                    case "==": Type = TokenType.Operator; Operator = OperatorType.Equal; return;
                    case "!=": Type = TokenType.Operator; Operator = OperatorType.NotEqual; return;
                    case "<": Type = TokenType.Operator; Operator = OperatorType.Less; return;
                    case ">": Type = TokenType.Operator; Operator = OperatorType.More; return;
                    case "<=": Type = TokenType.Operator; Operator = OperatorType.LessOrEqual; return;
                    case ">=": Type = TokenType.Operator; Operator = OperatorType.MoreOrEqual; return;
                    case "+": Type = TokenType.Operator; Operator = OperatorType.Plus; return;
                    case "-": Type = TokenType.Operator; Operator = OperatorType.Minus; return;
                    case "~": Type = TokenType.Operator; Operator = OperatorType.UnaryMinus; return;
                    case "*": Type = TokenType.Operator; Operator = OperatorType.Multiply; return;
                    case "/": Type = TokenType.Operator; Operator = OperatorType.Divide; return;
                    case "^": Type = TokenType.Operator; Operator = OperatorType.Power; return;
                    case "!": Type = TokenType.Operator; Operator = OperatorType.NOT; return;
                    case "true":
                    case "yes": Type = TokenType.Boolean; _boolean = true; return;
                    case "false":
                    case "no": Type = TokenType.Boolean; _boolean = false; return;
                }
                if (int.TryParse(t, out _number)) { Type = TokenType.Numeric; return; }
                _virtual = true;
                _operand = t;
                Type = t.Contains('.') ? TokenType.Numeric : TokenType.Boolean;
            }

            internal Token(int value)
            {
                _number = value;
                _boolean = false;
                _operand = "";
                _virtual = false;
                Type = TokenType.Numeric;
                Operator = OperatorType.AND;
            }

            internal Token(bool value)
            {
                _number = 0;
                _boolean = value;
                _operand = "";
                _virtual = false;
                Type = TokenType.Boolean;
                Operator = OperatorType.AND;
            }

            public override string ToString()
            {
                if (_virtual) return _operand;

                switch(Type)
                {
                    case TokenType.Boolean: return _boolean.ToString();
                    case TokenType.Numeric: return _number.ToString();
                    case TokenType.Operator:
                        switch(Operator)
                        {
                            case OperatorType.Ternar: return "?:";
                            case OperatorType.OR: return "||";
                            case OperatorType.AND: return "&&";
                            case OperatorType.Equal: return "==";
                            case OperatorType.NotEqual: return "!=";
                            case OperatorType.Less: return "<";
                            case OperatorType.More: return ">";
                            case OperatorType.LessOrEqual: return "<=";
                            case OperatorType.MoreOrEqual: return ">=";
                            case OperatorType.Plus: return "+";
                            case OperatorType.Minus: return "-";
                            case OperatorType.UnaryMinus: return "~";
                            case OperatorType.Multiply: return "*";
                            case OperatorType.Divide: return "/";
                            case OperatorType.Power: return "^";
                            case OperatorType.NOT: return "!";
                            default: return "Error";
                        }
                    default: return "Error";
                }
            }
        }

        private enum TokenType
        {
            Boolean,
            Numeric,
            Operator
        }

        private enum OperatorType
        {
            Ternar,
            OR,
            AND,
            Equal,
            NotEqual,
            Less,
            More,
            LessOrEqual,
            MoreOrEqual,
            Plus,
            Minus,
            UnaryMinus,
            Multiply,
            Divide,
            Power,
            NOT
        }
    }
}
