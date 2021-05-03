﻿using MatchGame.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace MatchGame
{
    public partial class GameWindow : Window
    {
        private Random random = new Random();
        private DispatcherTimer timer = new DispatcherTimer();
        List<Card> cards = new List<Card>();
        List<string> symbols = new List<string>()
        {
            "!", "!", "N", "N", ",", ",",
            "b", "b", "v", "v", "w", "w",
        };
        private Card card1 = null;
        private Card card2 = null;
        public GameWindow()
        {
            timer.Interval = TimeSpan.FromSeconds(1.0);
            timer.Tick += TimerTick;
        }
        public void RegisterCard(Card card)
        {
            card.State = Card.eState.Idle;
            int r = random.Next(symbols.Count);
            card.Symbol = symbols[r];
            symbols.RemoveAt(r);
            cards.Add(card);
        }
        public void SelectCard(Card card)
        {
            if (card1 == null)
            {
                //set card1 to card
            }
            else
            {
                //set card2 to card
                if (card1.Symbol == card2.Symbol)
                {
                    //set card1 and card2 to matched
                    //set card1 and card2 to null
                }
                else
                {
                    //disable all cards, so they can't be selected for a second
                    //this allows the player to see the flipped card for a moment
                    foreach (Card c in cards)
                    {
                        if (c.State == Card.eState.Idle)
                        {
                            //set card to inactive
                        }
                    }
                    //start timer, after a second the TimerTick is called and the cards reset
                }
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            foreach (Card c in cards)
            {
                if (!(c.State == Card.eState.Matched))
                {
                    c.State = Card.eState.Idle;
                }
                card1 = null;
                card2 = null;
            }
        }

        internal void SetCard(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
