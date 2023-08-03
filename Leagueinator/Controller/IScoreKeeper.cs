using Leagueinator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Controller {
    public interface IScoreKeeper {
        string[] Labels { get; }
        Score this[PlayerInfo pi]{ get; }

        Score this[Team team] { get; }
    }
}
