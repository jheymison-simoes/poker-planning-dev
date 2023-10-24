using Newtonsoft.Json;

namespace Shared.Helpers;

public static class ExtensionsHelpers
{
    // public static T DeepClone<T>(this T source)
    // {
    //     T newObject = (T)Activator.CreateInstance(typeof(T));
    //     var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
    //     var destProps = typeof(T).GetProperties().Where(x => x.CanWrite).ToList();
    //
    //     foreach (var sourceProp in sourceProps)
    //     {
    //         if (destProps.Any(x => x.Name == sourceProp.Name))
    //         {
    //             var p = destProps.First(x => x.Name == sourceProp.Name);
    //             if (p.CanWrite)
    //             {
    //                 p.SetValue(newObject, sourceProp.GetValue(source, null), null);
    //             }
    //         }
    //     }
    //
    //     return newObject;
    // }
    
    /// <summary>
    /// Perform a deep Copy of the object, using Json as a serialization method. NOTE: Private members are not cloned using this method.
    /// </summary>
    /// <typeparam name="T">The type of object being copied.</typeparam>
    /// <param name="source">The object instance to copy.</param>
    /// <returns>The copied object.</returns>
    public static T DeepClone<T>(this T source)
    {            
        if (ReferenceEquals(source, null)) return default;
        var deserializeSettings = new JsonSerializerSettings {ObjectCreationHandling = ObjectCreationHandling.Replace};

        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
    }
}