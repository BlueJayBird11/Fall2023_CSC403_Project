using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fall2020_CSC403_Project
{
    public class LanguageSelector
    {
        public Dictionary<string, List<string>> EnglishDialogue;
        public Dictionary<string, List<string>> SpanishDialogue;
        public Dictionary<string, List<string>> GermanDialogue;
        public Dictionary<string, List<string>> LatinDialogue;

        public Dictionary<string, string> EnglishLabel;
        public Dictionary<string, string> SpanishLabel;
        public Dictionary<string, string> GermanLabel;
        public Dictionary<string, string> LatinLabel;

        public LanguageSelector()
        {
            EnglishDialogue = new Dictionary<string, List<string>>();
            SpanishDialogue = new Dictionary<string, List<string>>();
            GermanDialogue = new Dictionary<string, List<string>>();
            LatinDialogue = new Dictionary<string, List<string>>();

            EnglishLabel = new Dictionary<string, string>();
            SpanishLabel = new Dictionary<string, string>();
            GermanLabel = new Dictionary<string, string>();
            LatinLabel = new Dictionary<string, string>();


            EnglishDialogue.Add("koolaidManDialogue", new List<string> { "You hear a slight rumble...", "Koolaid Man breaks through the wall", "\"OHH, YEAH\"" });
            SpanishDialogue.Add("koolaidManDialogue", new List<string> { "Escuchas un leve retumbar...", "Koolaid Man rompe la pared", "\"¡OHH, SÍ!\"" });
            GermanDialogue.Add("koolaidManDialogue", new List<string> { "Du hörst ein leichtes Grollen...", "Der Kool-Aid Mann bricht durch die Wand", "\"OHH, JA\"" });
            LatinDialogue.Add("koolaidManDialogue", new List<string> { "Murmur parvum audis...", "Errumpit Homo Koolaidensis per parietem", "\"IO\""});

            EnglishDialogue.Add("poisonKoolaidDialogue", new List<string> { "neurotoxins" });
            SpanishDialogue.Add("poisonKoolaidDialogue", new List<string> { "neurotoxinas" });
            GermanDialogue.Add("poisonKoolaidDialogue", new List<string> { "Neurotoxinen" });
            LatinDialogue.Add("poisonKoolaidDialogue", new List<string> { "neurotoxica" });

            EnglishDialogue.Add("cheetoDialogue", new List<string> { "HOW DO YOU EXPECT TO FIGHT", "WHEN YOUR HANDS ARE COVERED IN CHEETO DUST!" });
            SpanishDialogue.Add("cheetoDialogue", new List<string> { "CÓMO PRETENDES PELEAR", "¡CUANDO TUS MANOS ESTÁN CUBIERTAS DE POLVO DE CHEETOS!" });
            GermanDialogue.Add("cheetoDialogue", new List<string> { "WIE ERWARTEST DU ZU KÄMPFEN", "WENN DEINE HÄNDE MIT CHEETO-STAUB BEDECKT SIND!" });
            LatinDialogue.Add("cheetoDialogue", new List<string> { "QUŌMODO INTENDAS PUGNĀRE", "CŪM MANŪS TUAE PULVERE CHEETONI TECTAE SINT!" });

            EnglishLabel.Add("TimeLabel", "Time: ");
            SpanishLabel.Add("TimeLabel", "Tiempo: ");
            GermanLabel.Add("TimeLabel", "Zeit: ");
            LatinLabel.Add("TimeLabel", "Tempus: ");

            EnglishLabel.Add("AttackLabel", "Attack");
            SpanishLabel.Add("AttackLabel", "Atacar");
            GermanLabel.Add("AttackLabel", "Kampf");
            LatinLabel.Add("AttackLabel", "Aggredi");

        }

        public List<string> GetDialogue(string key, string language)
        {
            if (language == "English")
            {
                return EnglishDialogue[key];
            }
            else if (language == "Spanish")
            {
                return SpanishDialogue[key];
            }
            else if (language == "German")
            {
                return GermanDialogue[key];
            }
            else if (language == "Latin")
            {
                return LatinDialogue[key];
            }
            return null;
        }

        public string GetLabels(string key, string language)
        { 
            if (language == "English")
            {
                return EnglishLabel[key];
            }
            else if (language == "Spanish")
            {
                return SpanishLabel[key];
            }
            else if (language == "German")
            {
                return GermanLabel[key];
            }
            else if (language == "Latin")
            {
                return LatinLabel[key];
            }
            return null;
        }
    }
}
