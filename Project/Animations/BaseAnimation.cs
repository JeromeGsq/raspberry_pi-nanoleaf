using nano.Project.Interfaces;
using nano.Project.Models;
using rpi_ws281x;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace nano.Project.Animations
{
    public abstract class BaseAnimation : IAnimation
    {
        private WS281x rpi;

        protected Controller Controller { get; private set; }

        protected virtual bool Loop { get; set; } = false;
        protected virtual int TickDuration { get; set; } = 16;
        protected int LedCount { get; set; }
        protected List<LedGroup> LedGroup { get; set; }

        public void Init(WS281x rpi, int ledCount)
        {
            this.rpi = rpi;
            this.LedCount = ledCount;

            this.Controller = this.rpi.GetController();

            this.LedGroup = new List<LedGroup>();
            for (int i = 0; i < this.LedCount; i++)
            {
                this.LedGroup.Add(new LedGroup());
            }
        }

        public virtual void Start()
        {
        }

        public virtual bool Update()
        {
            return true;
        }

        public virtual void End()
        { 
            this.Clear();
        }

        public void Apply()
        {
            for (int i = 0; i < this.LedGroup.Count; i++)
            {
                this.Controller?.SetLED(i, this.LedGroup[i].Color);
            }
            this.rpi?.Render();
        }

        public void Clear()
        {
            this.rpi?.SetAll(Color.Black);
        }
    }
}
