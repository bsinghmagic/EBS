using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
  /// <summary>
  /// Helper methods for the lists.
  /// </summary>
  public static class ListExtensions
  {
    public static List<string> ChunkBy<T>(this List<T> source, int chunkSize)
    {
      List<string> result = new List<string>();
      var list= source
          .Select((x, i) => new { Index = i, Value = x })
          .GroupBy(x => x.Index / chunkSize)
          .Select(x => x.Select(v => v.Value).ToList())
          .ToList();

      foreach(var val in list)
      {
        result.Add(JsonConvert.SerializeObject(val));

      }

      return result;
    }

    public static IEnumerable<IEnumerable<T>> ToChunks<T>(this IEnumerable<T> enumerable,
                                                      int chunkSize)
    {
      int itemsReturned = 0;
      var list = enumerable.ToList(); // Prevent multiple execution of IEnumerable.
      int count = list.Count;
      while (itemsReturned < count)
      {
        int currentChunkSize = Math.Min(chunkSize, count - itemsReturned);
        yield return list.GetRange(itemsReturned, currentChunkSize);
        itemsReturned += currentChunkSize;
      }
    }
  }
}
