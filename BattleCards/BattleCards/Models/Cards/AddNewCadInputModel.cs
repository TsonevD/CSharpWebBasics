﻿namespace BattleCards.Models.Cards
{
    public class AddNewCadInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Keyword { get; set; }

        public string Image { get; set; }

        public int Attack { get; set; }
        public int Health { get; set; }
    }
}
