using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ClientListenerLibrary
{
	public class ObjectSerializerDeserializer<Entity>
	{
		// Convert an object/Entity to a byte array
		public byte[] ObjectToByteArray(Entity entity)
		{
			if(entity == null)
				return null;

			byte[] byteArray;

			using (MemoryStream memStream = new MemoryStream ()) {
				BinaryFormatter binForm = new BinaryFormatter();
				binForm.Serialize(memStream, entity);

				byteArray = memStream.ToArray ();
			}

			return byteArray;
		}

		// Convert a byte array to an Object/Entity
		public Entity ByteArrayToObject(byte[] arrayBytes)
		{
			Entity entity;

			using (MemoryStream memStream = new MemoryStream ()) {
				BinaryFormatter binForm = new BinaryFormatter();
				memStream.Write(arrayBytes, 0, arrayBytes.Length);
				memStream.Seek(0, SeekOrigin.Begin);
				entity = (Entity) binForm.Deserialize(memStream);
			}

			return entity;
		}
	}
}

