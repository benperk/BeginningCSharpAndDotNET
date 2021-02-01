using System;
using System.Collections.Generic;
using System.Text;

namespace Ch12Ex03
{
    public class VectorList : List<Vector>
    {
        public VectorList() : base() { }
        public VectorList(IEnumerable<Vector> initialItems)
        {
            foreach (Vector vector in initialItems)
            {
                Add(vector);
            }
        }
        public string Sum()
        {
            StringBuilder sb = new StringBuilder();
            Vector currentPoint = new Vector(0.0, 0.0);
            sb.Append("origin");
            foreach (Vector vector in this)
            {
                sb.AppendFormat($" + {vector}");
                currentPoint += vector;
            }
            sb.AppendFormat($" = {currentPoint}");
            return sb.ToString();
        }
    }
}
