using osu.Framework.Bindables;
using osu.Game.Rulesets.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace osu.Game.Rulesets.Tau.UI.Scrolling
{
    /// <summary>
    /// A type of <see cref="Playfield"/> specialized towards scrolling <see cref="DrawableHitObject"/>s spesifically for tau.
    /// </summary>
    public class TauScrollingPlayfield : Playfield
    {
        protected readonly IBindable<TauScrollingDirection> Direction = new Bindable<TauScrollingDirection>();

        [Resolved]
        private ITauScrollingInfo scrollingInfo { get; set; }

        [BackgroundDependencyLoader]
        private void load()
        {
            Direction.BindTo(scrollingInfo.Direction);
        }

        protected sealed override HitObjectContainer CreateHitObjectContainer() => new ScrollingHitObjectContainer();
    }
}
