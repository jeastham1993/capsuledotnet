using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CapsuleDotNet.Models{
    public class Entry
    {
        [JsonProperty("parties")]
        private List<Party> _parties;

        [JsonProperty("participants")]
        private List<Participant> _participants;

        [JsonProperty("attachments")]
        private List<Attachment> _attachments;
        private Entry(string type){
            this.Type = type;
        }

        public static Entry Create(EntryType type){
            return new Entry(type.ToFriendlyString());
        }

        public long? Id { get; private set; }
        public string Type { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? EntryAt { get; set; }
        public DateTime Subject { get; set; }
        public String Content { get; set; }
        public IReadOnlyCollection<Attachment> Attachments => _attachments;
        public User Creator { get; set; }
        public ActivityType ActivityType { get; set; }
        public Case Kase { get; set; }
        public Opportunity Opportunity { get; set; }
        public Party Party { get; set; }
        public IReadOnlyCollection<Party> Parties => _parties;
        public IReadOnlyCollection<Participant> Participants => _participants;

        public void AddParty(Party party){
            if (this._parties == null){
                _parties = new List<Party>(1);
            }

            _parties.Add(party);
        }

        public void RemoveParty(long id){
            if (this._parties != null && this._parties.Any(p => p.Id == id)){
                _parties.Remove(_parties.FirstOrDefault(p => p.Id == id));
            }
        }

        public void AddParticipant(string address, string name, ParticipantRole role){
            if (this._participants == null){
                _participants = new List<Participant>(1);
            }

            _participants.Add(Participant.Create(address, name, role));
        }

        public void RemoveParticipant(long id){
            if (this._participants != null && this._participants.Any(p => p.Id == id)){
                _participants.Remove(_participants.FirstOrDefault(p => p.Id == id));
            }
        }
    
        public bool AddAttachment(string filePath){
            if (this._attachments == null){
                this._attachments = new List<Attachment>(1);
            }

            this._attachments.Add(Attachment.Create(filePath));

            return true;
        }
    }
}