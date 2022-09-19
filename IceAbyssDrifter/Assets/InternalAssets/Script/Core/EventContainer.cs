using System;

namespace RimuruDev
{
    public static class EventContainer
    {
        public static Action<string> OnAddOreAction;

        public static void SendAboutExtractionOre(string id)
        {
            if (OnAddOreAction != null) OnAddOreAction.Invoke(id);
        }
    }
}