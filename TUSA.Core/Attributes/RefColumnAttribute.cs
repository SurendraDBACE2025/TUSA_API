namespace TUSA.Core.Attributes
{
    public class RefColumnAttribute : System.Attribute
    {
        public string ColumnName { get; }

        public RefColumnAttribute(string name)
        {
            this.ColumnName = name;
        }
    }
}