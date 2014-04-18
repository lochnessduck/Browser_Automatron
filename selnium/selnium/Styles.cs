using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace selnium
{
    enum Style
    {
        HighlightYellow,
        HighlightRed
    }
    
    class Stylesheet
    {
        public Dictionary<Style, string> styles;

        public string Get(Style styleIndex) {
            return this.styles[styleIndex];
        }

        public Stylesheet()
        {
            this.styles = new Dictionary<Style, string>();
            this.styles.Add(Style.HighlightYellow, "background-color:yellow; border: 2px solid yellow;");
            this.styles.Add(Style.HighlightRed, "background-color:red; color: white;");
        }
    }
}
