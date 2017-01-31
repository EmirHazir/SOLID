using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Solid.WebUI.ExtentionForSession
{
    public static class SessionExtensionMetod
    {
        //sen bana sessionu keyi ve değeri ver ben onu döndüreyim diyorum
        public static void SetObject(this ISession session,string key, object value)
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key, objectString);
        }

        //sen bana key tipini ver ben onun dönüş tipini kendim belirleyeceğim bu yüzden T verdim
        public static T GetObject<T>(this ISession session,string key)
            where T:class
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString))//sessionda bir değer yoksa
            {
                return null;
            }

            //varsa objectStringi bir T türünde geri döndür.
            T value = JsonConvert.DeserializeObject<T>(objectString);
            return value;
        }
    }
}
