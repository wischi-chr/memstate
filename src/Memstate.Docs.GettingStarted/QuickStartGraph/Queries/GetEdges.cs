using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Memstate.Models.Graph;
using static Memstate.Models.Graph.GraphModel;

namespace Memstate.Docs.GettingStarted.QuickStartGraph.Queries
{
    public class GetEdges : Query<GraphModel, IEnumerable<Edge>>
    {
        public override IEnumerable<Edge> Execute(GraphModel db) => new List<Edge>(db.Edges);
    }
}
