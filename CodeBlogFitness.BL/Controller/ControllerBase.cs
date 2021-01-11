using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {

                //if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                if (fs.Length > 0)
                {
                    if(formatter.Deserialize(fs) is T items)
                    {
                        return items;
                    }                        
                }                
            }
            return default(T);
        }
    }
}
