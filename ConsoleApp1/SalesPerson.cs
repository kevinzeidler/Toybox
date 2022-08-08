using System.Text;

namespace ConsoleApp1
{
    public class SalesPerson
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Region { get; set; }

        public string ProductType { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(nameof(SalesPerson));
            stringBuilder.Append(" {\n");

            if (PrintMembers(stringBuilder))
                stringBuilder.Append(" ");

            stringBuilder.Append("\n}");

            return stringBuilder.ToString();
        }

        protected virtual bool PrintMembers(StringBuilder builder)
        {
            builder.Append("  " + nameof(ID));
            builder.Append(" = ");
            builder.Append(ID);
            builder.Append(", \n");
            builder.Append("  " + nameof(Address));
            builder.Append(" = ");
            builder.Append(Address);
            builder.Append(", \n");
            builder.Append("  " + nameof(City));
            builder.Append(" = ");
            builder.Append(City);
            builder.Append("  " + nameof(Name));
            builder.Append(" = ");
            builder.Append(Name);


            return true;
        }
    }
}