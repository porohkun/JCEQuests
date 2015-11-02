using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCEQuests.Quests.Conditions
{
    public class Condition
    {

        internal bool Check(Quest quest)
        {
            return true;
        }

        internal static Condition Create(PNetJson.JSONValue jSONValue)
        {
            return new Condition();
        }
    }
}
