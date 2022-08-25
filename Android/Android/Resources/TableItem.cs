namespace Android.Resources
{
    internal class TableItem{
        public string key { get; set; }
        public string value { get; set; }

        public TableItem(string Key, string Value){
            this.key = Key;
            this.value = Value;
        }
    }
}