using MessagePack;
using MessagePack.Formatters;

namespace Passive.API.Formatters
{
    public class DBNullFormatter : IMessagePackFormatter<DBNull>
    {
        public static DBNullFormatter Instance = new();

        private DBNullFormatter()
        {
        }

        public void Serialize(ref MessagePackWriter writer, DBNull value, MessagePackSerializerOptions options)
        {
            writer.WriteNil();
        }

        public DBNull Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options) => DBNull.Value;
    }
}
