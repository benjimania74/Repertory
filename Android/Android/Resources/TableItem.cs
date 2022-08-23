namespace Android.Resources
{
    internal class TableItem{
        public string key { get; }
        public string value { get; }

        public TableItem(string Key, string Value){
            this.key = Key;
            this.value = Value;
        }
    }
}