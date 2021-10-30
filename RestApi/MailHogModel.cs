using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantisbt.RestApi
{
    public class MailHogModel
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class From
    {
        [JsonProperty("Relays")]
        public object Relays { get; set; }

        [JsonProperty("Mailbox")]
        public string Mailbox { get; set; }

        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("Params")]
        public string Params { get; set; }
    }

    public class To
    {
        [JsonProperty("Relays")]
        public object Relays { get; set; }

        [JsonProperty("Mailbox")]
        public string Mailbox { get; set; }

        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("Params")]
        public string Params { get; set; }
    }

    public class Headers
    {
        [JsonProperty("Auto-Submitted")]
        public List<string> AutoSubmitted { get; set; }

        [JsonProperty("Content-Transfer-Encoding")]
        public List<string> ContentTransferEncoding { get; set; }

        [JsonProperty("Content-Type")]
        public List<string> ContentType { get; set; }

        [JsonProperty("Date")]
        public List<string> Date { get; set; }

        [JsonProperty("From")]
        public List<string> From { get; set; }

        [JsonProperty("MIME-Version")]
        public List<string> MIMEVersion { get; set; }

        [JsonProperty("Message-ID")]
        public List<string> MessageID { get; set; }

        [JsonProperty("Received")]
        public List<string> Received { get; set; }

        [JsonProperty("Return-Path")]
        public List<string> ReturnPath { get; set; }

        [JsonProperty("Subject")]
        public List<string> Subject { get; set; }

        [JsonProperty("To")]
        public List<string> To { get; set; }

        [JsonProperty("X-Auto-Response-Suppress")]
        public List<string> XAutoResponseSuppress { get; set; }

        [JsonProperty("X-Mailer")]
        public List<string> XMailer { get; set; }

        [JsonProperty("CC")]
        public List<string> CC { get; set; }

        [JsonProperty("Reply-To")]
        public List<string> ReplyTo { get; set; }
    }

    public class Content
    {
        [JsonProperty("Headers")]
        public Headers Headers { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }

        [JsonProperty("Size")]
        public int Size { get; set; }

        [JsonProperty("MIME")]
        public object MIME { get; set; }
    }

    public class Part
    {
        [JsonProperty("Headers")]
        public Headers Headers { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }

        [JsonProperty("Size")]
        public int Size { get; set; }

        [JsonProperty("MIME")]
        public object MIME { get; set; }
    }

    public class MIME
    {
        [JsonProperty("Parts")]
        public List<Part> Parts { get; set; }
    }

    public class Raw
    {
        [JsonProperty("From")]
        public string From { get; set; }

        [JsonProperty("To")]
        public List<string> To { get; set; }

        [JsonProperty("Data")]
        public string Data { get; set; }

        [JsonProperty("Helo")]
        public string Helo { get; set; }
    }

    public class Item
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("From")]
        public From From { get; set; }

        [JsonProperty("To")]
        public List<To> To { get; set; }

        [JsonProperty("Content")]
        public Content Content { get; set; }

        [JsonProperty("Created")]
        public DateTime Created { get; set; }

        [JsonProperty("MIME")]
        public MIME MIME { get; set; }

        [JsonProperty("Raw")]
        public Raw Raw { get; set; }
    }


}
