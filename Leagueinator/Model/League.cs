﻿using System;
using System.Collections.Generic;
using Leagueinator.Utility_Classes;
using Leagueinator.Model.Settings;

namespace Leagueinator.Model {
    [Serializable]
    public class League {
        public readonly Settings.Setting settings;

        [Model] public List<LeagueEvent> Events { get; private set; } = new List<LeagueEvent>();

        /// <summary>
        /// Add a new Event to the league.
        /// Will add all current league players to the event.
        /// </summary>
        /// <returns></returns>
        public LeagueEvent AddEvent(string eventName, string date, Setting settings) {
            var lEvent = new LeagueEvent(eventName, date, settings);
            var round = lEvent.NewRound();
            round.IdlePlayers.AddRange(this.SeekDeep<PlayerInfo>().Unique());
            this.Events.Add(lEvent);
            return lEvent;
        }

        /// <summary>
        /// Construct a detailed string representation of a League object by combining 
        /// information about players and events, separated by newlines, and presented 
        /// in a formatted manner.
        /// </summary>
        /// <returns></returns>
        public XMLStringBuilder ToXML() {
            XMLStringBuilder xsb = new XMLStringBuilder();
            xsb.OpenTag("League", $"hash='{this.GetHashCode().ToString("X")}'");
            xsb.InlineTag("Players", this.SeekDeep<PlayerInfo>().DelString());
            foreach (var lEvent in this.Events) {
                xsb.AppendXML(lEvent.ToXML());
            }
            xsb.CloseTag();
            return xsb;
        }

        public override string ToString() {
            return this.ToXML().ToString();
        }
    }
}
