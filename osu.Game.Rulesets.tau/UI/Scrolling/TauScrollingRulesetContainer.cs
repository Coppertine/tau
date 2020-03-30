using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Input.Bindings;
using osu.Framework.Lists;
using osu.Game.Configuration;
using osu.Game.Input.Bindings;
using osu.Game.Rulesets.Tau.Objects;
using osu.Game.Rulesets.Tau.UI.Scrolling.Algorithms;
using osu.Game.Rulesets.Timing;
using osu.Game.Rulesets.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace osu.Game.Rulesets.Tau.UI.Scrolling
{
    /// <inheritdoc />
    /// <summary>
    /// A type of <see cref="!:RulesetContainer{TPlayfield,TObject}" /> that supports a <see cref="T:osu.Game.Rulesets.Tau.UI.Scrolling.TauScrollingPlayfield" />.
    /// <see cref="!:HitObject" />s inside this <see cref="!:RulesetContainer{TPlayfield,TObject}" /> will scroll within the playfield.
    /// </summary>
    public class TauScrollingRulesetContainer<TPlayfield, TObject> : Rulesets.UI.RulesetContainer<TPlayfield, TObject>, IKeyBindingHandler<GlobalAction>
        where TObject : TauHitObject
        where TPlayfield : TauScrollingPlayfield
    {
        /// <summary>
        /// The default span of time visible by the length of the scrolling circle.
        /// This is clamped between <see cref="time_span_min"/> and <see cref="time_span_max"/>.
        /// </summary>
        private const double time_span_default = 1500;

        /// <summary>
        /// The minimum span of time that may be visible by the length of the scrolling circle.
        /// </summary>
        private const double time_span_min = 50;

        /// <summary>
        /// The maximum span of time that may be visible by the length of the scrolling circle.
        /// </summary>
        private const double time_span_max = 10000;

        /// <summary>
        /// The step increase/decrease of the span of time visible by the length of the scrolling circle.
        /// </summary>
        private const double time_span_step = 200;

        protected readonly Bindable<TauScrollingDirection> Direction = new Bindable<TauScrollingDirection>();

        /// <summary>
        /// The span of time that is visible by the length of the scrolling circle.
        /// For example, only hit objects with start time less than or equal to 1000 will be visible with <see cref="TimeRange"/> = 1000.
        /// </summary>
        protected readonly BindableDouble TimeRange = new BindableDouble(time_span_default)
        {
            Default = time_span_default,
            MinValue = time_span_min,
            MaxValue = time_span_max
        };

        protected virtual ScrollVisualisationMethod VisualisationMethod => ScrollVisualisationMethod.Sequential;

        /// <summary>
        /// Whether the player can change <see cref="VisibleTimeRange"/>.
        /// </summary>
        protected virtual bool UserScrollSpeedAdjustment => true;

        // <summary>
        /// Provides the default <see cref="MultiplierControlPoint"/>s that adjust the scrolling rate of <see cref="TauHitObject"/>s
        /// inside this <see cref="RulesetContainer{TPlayfield,TObject}"/>.
        /// </summary>
        /// <returns></returns>
        private readonly SortedList<MultiplierControlPoint> controlPoints = new SortedList<MultiplierControlPoint>(Comparer<MultiplierControlPoint>.Default);

        protected ITauScrollingInfo ScrollingInfo => scrollingInfo;

        [Cached(Type = typeof(ITauScrollingInfo))]
        private readonly LocalScrollingInfo scrollingInfo;


        private class LocalScrollingInfo : ITauScrollingInfo
        {
            public IBindable<TauScrollingDirection> Direction { get; } = new Bindable<TauScrollingDirection>();

            public IBindable<double> TimeRange { get; } = new BindableDouble();

            public ITauScrollAlgorithm Algorithm { get; set; }
        }
    }


}
