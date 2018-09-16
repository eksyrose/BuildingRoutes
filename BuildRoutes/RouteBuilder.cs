using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildRoutes
{
    public class RouteBuilder
    {
        List<Path> paths = new List<Path>();  //paths 
        List<String> routes = new List<String>();  //routes (result)

        public String[] BuildRoute(Path[] pths)
        {
            foreach (Path p in pths)
                paths.Add(p);
            Sort();
            return routes.ToArray();            
        }

        private void Sort()
        {
            int to = paths.Count - 1;
            for (int i = 0; i <= paths.Count - 1; i++) //first we searching for the rightest part
            {
                int place = FindRightPair(paths[i], 0, to);  
                if (place != i) // if now on the wrong place
                {
                    Path temp = paths[i];
                    paths.RemoveRange(i, 1);
                    paths.Insert(place, temp);
                }
                if (place == to)  //it's the rightest part, then break & go from right to left.
                {
                    to--;
                    break;
                }
            }
            for (int i = to; i >= 0; i--)
            {
                int place = FindLeftPair(paths[i+1], 0, i+1); //now we adding parts from right to left like a domino                
                Path temp = paths[place];
                paths.RemoveRange(place, 1);
                paths.Insert(i, temp);
            }
            routes.Add(paths[0].From);  //convert from paths[] to List<String>
            for (int i = 0; i < paths.Count; i++)
                routes.Add(paths[i].To);
        }

        int FindLeftPair(Path p, int from, int to) //
        {
            int res = 0;
            for (int i = from; i < to; i++)
                if (paths[i].To.Equals(p.From))
                {
                    res = i;
                    break;
                }
            return res;
        } 

        int FindRightPair(Path p, int from, int to) //
        {
            int res = to;
            for (int i = from; i <= to; i++)
                if ((paths[i].From.Equals(p.To)) && (i != paths.IndexOf(p)))
                {
                    res = i - 1;
                    break;
                }
            if (res < 0) res++;
            return res;
        }
    }
}
