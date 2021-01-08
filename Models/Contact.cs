using System;
using System.Collections.Generic;
using System.Text;

namespace Buddiegram.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string[] Emails { get; set; }
        public string[] PhoneNumbers { get; set; }
        public bool ROWCHECK { get; internal set; }

        public bool IsChecked { get; set; }
    }
}
