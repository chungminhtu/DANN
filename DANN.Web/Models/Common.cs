using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DANN.Web.Models
{
    public class Common
    {
    }

    public class CommandPanelOptions
    {
        public CommandPanelOptions()
        {
            controlIndex = 0;
            controlName = "null";
            control2Name = "null";
            Add = true;
            Edit = true;
            Delete = true;
            Save = true;
            Reload = true;
            Cancel = true;
            Print = true;
            CondictionToAutoSave = "";
        }
        public int controlIndex { get; set; }
        public string controlName { get; set; }
        public string control2Name { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Save { get; set; }
        public bool Reload { get; set; }
        public bool Cancel { get; set; }
        public bool Print { get; set; }
        public string CondictionToAutoSave { get; set; }
    }
}