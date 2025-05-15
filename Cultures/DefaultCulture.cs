using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Cultures
{
    public class DefaultCulture : ICulture
    {
        private RandomNumberGenerator _rand;

        public DefaultCulture(RandomNumberGenerator rand)
        {
            _rand = rand;
        }

        public string GetRandomMaleName()
        {
            var names = GetMaleNames();
            return names[_rand.GenerateBetween(0, names.Count - 1)];
        }

        public string GetRandomFemaleName()
        {
            var names = GetFemaleNames();
            return names[_rand.GenerateBetween(0, names.Count - 1)];
        }

        public List<string> GetMaleNames()
        {
            List<string> MaleNames = new()
            {
                "Ainsley", "Aldridge", "Aldwyn", "Alger", "Axton", "Ashliegh", "Athelstan", "Arley", "Barton",
                "Barclay", "Blaxton", "Bradley", "Bray", "Brett", "Bromley", "Buckley", "Burke", "Burley",
                "Byford", "Calder", "Calvert", "Chadwick", "Chetwin", "Cromwell", "Dalbert", "Dallin", "Delwyn",
                "Dempster", "Denley", "Derward", "Dryden", "Dwennon", "Earl", "Edbert", "Edlin", "Egerton",
                "Eldric", "Elvin", "Elwood", "Elvy", "Erwin", "Everard", "Fairley", "Fane", "Fenwick", "Fielding",
                "Firth", "Frayne", "Freeman", "Fuller", "Fulton", "Gladstone", "Goddard", "Gomer", "Graeme",
                "Grantham", "Gresham", "Hadley", "Haddon", "Haig", "Hagley", "Hampton", "Hamilton", "Hardwin",
                "Hargreave", "Harlan", "Haven", "Hayden", "Hayes", "Heathcote", "Hedley", "Holmes", "Hollis",
                "Huntley", "Huxley", "Jamieson", "Jefferson", "Kemp", "Kenley", "Kenrick", "Kenton", "Kingston",
                "Kinsey", "Kirkley", "Kirkwood", "Kyne", "Laibrook", "Lane", "Langley", "Langworth", "Lancelot",
                "Lawford", "Lawson", "Leigh", "Leverton", "Linford", "Linley", "Linwood", "Litton", "Livingston",
                "Locke", "Lockwood", "Macy", "Manning", "Marden", "Marlow", "Marley", "Medwin", "Mead", "Merrill",
                "Milbourn", "Millard", "Milford", "Morland", "Morley", "Morton", "Nash", "Nickson", "Norville",
                "Norvin", "Norwood", "North", "Nyle", "Oglesby", "Ordway", "Orford", "Orman", "Ormond", "Osmar",
                "Osmond", "Oxford", "Oxton", "Packard", "Palmer", "Patton", "Paxton", "Pelton", "Penley", "Pollock",
                "Prescott", "Presley", "Radborne", "Radcliff", "Radford", "Radnor", "Raleigh", "Ramsay", "Ramsden",
                "Randall", "Randell", "Randolph", "Ranald", "Ransley", "Ransom", "Raven", "Rayburn", "Raynold",
                "Reading", "Redford", "Reginald", "Reilly", "Remington", "Renfred", "Renshaw", "Reynold", "Ridgley",
                "Ridley", "Ridgeway", "Risley", "Riston", "Rockley", "Rockwell", "Ronald", "Ronson", "Rochester",
                "Rowell", "Rowley", "Rowson", "Roxbury", "Rufford", "Rumford", "Rushford", "Rutledge", "Rutley",
                "Ryle", "Ryley", "Safford", "Salisbury", "Salton", "Sanborn", "Saunderson", "Scott", "Sealey",
                "Seabert", "Seabrook", "Seaborne", "Seger", "Sheldon", "Shepherd", "Sherborne", "Sherwood",
                "Shandy", "Shelley", "Snowden", "Somerset", "Somerville", "Southwell", "Stanford", "Stanhope",
                "Stanley", "Standish", "Starr", "Stockton", "Stratford", "Stratton", "Stroud", "Stowe", "Sykes",
                "Tannar", "Tarrant", "Tatum", "Teddie", "Tennyson", "Thatcher", "Thorne", "Thornton", "Thorpe",
                "Thurlow", "Thurstan", "Tilford", "Townsend", "Tranter", "Tripp", "Trowbridge", "Twyford", "Ulfred",
                "Udolf", "Unwin", "Upwood", "Upton", "Vail", "Vane", "Venn", "Waite", "Wakefield", "Walby",
                "Walwyn", "Warburton", "Warley", "Warmund", "Wainwright", "Webster", "Welby", "Wentworth",
                "Westbrook", "Westby", "Weston", "Whitby", "Whitcombe", "Whitfield", "Wheaton", "Wheeler",
                "Wickham", "Winston", "Wistan", "Witton", "Wyndham", "Wyndam", "Yale", "Yardley", "York", "Yule",
                "Zale"
            };
            return MaleNames;
        }

        public List<string> GetFemaleNames()
        {
            List<string> FemaleNames = new()
            {
                "Afton", "Agate", "Ainsley", "Alden", "Aldercy", "Aldora", "Alfreda", "Alison", "Allura", "Alodie",
                "Alvina", "Annice", "Arden", "Ashleigh", "Ashley", "Athela", "Audrey", "Aurelia", "Averil", "Bedelia",
                "Beda", "Beverley", "Birdie", "Blake", "Bliss", "Blythe", "Bonnie", "Braeden", "Brighton", "Briar",
                "Bunty", "Bunny", "Cam", "Candace", "Carleen", "Carling", "Carrington", "Cedrica", "Charlotte",
                "Cherilyn", "Chloe", "Clover", "Corliss", "Dahlia", "Dale", "Damosel", "Dana", "Daralis", "Darby",
                "Darrene", "Dawn", "Delwyn", "Dena", "Devona", "Duchess", "Eadda", "Eartha", "Ebba", "Edda", "Edith",
                "Edlyn", "Edmonda", "Edrea", "Edwina", "Eirlys", "Elethea", "Ellery", "Elmira", "Ember", "Emmet",
                "Eostre", "Erline", "Ethel", "Evelyn", "Faith", "Farley", "Farrah", "Fayre", "Felberta", "Fern",
                "Fernley", "Fleta", "Florence", "Flyta", "Forestyne", "Gaines", "Generia", "Geraldine", "Gerarda",
                "Gerry", "Gleda", "Godiva", "Goldie", "Grayson", "Gypsy", "Haiden", "Halsey", "Haralda", "Harley",
                "Harper", "Hazel", "Heather", "Hertha", "Hope", "Honbria", "Imogene", "Iria", "Ivy", "Jancis",
                "Janelle", "Jolene", "Joyce", "June", "Kaelyn", "Kendra", "Kestrel", "Kimberley", "Lana", "Landon",
                "Lane", "Langley", "Lark", "Lassie", "Lauren", "Leanne", "Leigh", "Levina", "Lillian", "Linley",
                "Lindley", "Lindon", "Lodema", "Lona", "Louella", "Louvaine", "Loveday", "Lucianna", "Luella",
                "Lyndal", "Lynn", "Maida", "Madison", "Maitane", "Marigold", "Marjorie", "Marlow", "Merrill",
                "Merry", "Mertice", "Melba", "Melinda", "Mercy", "Mildred", "Missy", "Misty", "Nara", "Nelda",
                "Nellwyn", "Norma", "Norvella", "Odella", "Oletha", "Opeline", "Orlan", "Ornelle", "Osma", "Paige",
                "Pamela", "Patience", "Payge", "Pebbles", "Pepper", "Perri", "Perry", "Petula", "Philberta", "Pixie",
                "Posy", "Poppy", "Primrose", "Quella", "Queena", "Rainbow", "Radella", "Rae", "Richelle", "Riley",
                "Roberta", "Robyn", "Roden", "Rowena", "Rue", "Rumer", "Ryesen", "Salal", "Scarlett", "Shelby",
                "Shelley", "Shirley", "Sigourney", "Skyla", "Skylar", "Sparrow", "Spring", "Starr", "Starling",
                "Stockard", "Storm", "Sunny", "Sunniva", "Sydney", "Tannar", "Tatum", "Teal", "Tempest", "Thistle",
                "Timber", "Timothea", "Tinble", "Tory", "Trilby", "Tuesday", "Twyla", "Tyler", "Unity", "Udele",
                "Ulrika", "Valora", "Vail", "Velma", "Velvet", "Vulpine", "Wallis", "Walker", "Wanetta", "Waverly",
                "Waynette", "Westina", "Whaley", "Whitney", "Whitley", "Whoopi", "Wilona", "Willow", "Winifred",
                "Winsome", "Wren", "Wylie", "Yardley", "Yetta", "Zanna", "Zenith", "Zephrine", "Zeta", "Zelene"
            };
            return FemaleNames;
        }
    }


}
