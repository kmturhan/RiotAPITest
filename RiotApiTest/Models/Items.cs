using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiotApiTest.Models
{
    public class Items
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PlainText { get; set; }
        public string colloq { get; set; }
        public List<string> into { get; set; }
        public Image Image { get; set; }
        public Gold Gold { get; set; }
        public List<string> Tags { get; set; }
        //public List<bool> Maps { get; set; }
        public Dictionary<string,string> Stats { get; set; }
    }
    public class Image
    {
        public string Full { get; set; }
        public string Sprite { get; set; }
        public string Group { get; set; }
    }
    public class Gold
    {
        public int Base { get; set; }
        public bool Purchasable { get; set; }
        public int Total { get; set; }
        public int Sell { get; set; }
    }
}