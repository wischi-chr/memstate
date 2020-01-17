using System.Collections.Generic;
using Memstate.Models.Graph;
using static Memstate.Models.Graph.GraphModel;

namespace Memstate.Docs.GettingStarted.QuickStartGraph.Queries
{
    public class GetNodes : Query<GraphModel, IEnumerable<Node>>
    {
        public override IEnumerable<Node> Execute(GraphModel db) => new List<Node>(db.Nodes);
    }
}
