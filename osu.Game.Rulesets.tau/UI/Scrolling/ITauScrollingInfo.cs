using osu.Framework.Bindables;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Tau.UI.Scrolling.Algorithms;

namespace osu.Game.Rulesets.Tau.UI.Scrolling
{
    public class ITauScrollingInfo
    {
        /// <summary>
        /// The direction <see cref="HitObject"/>s should scroll in.
        /// </summary>
        IBindable<TauScrollingDirection> Direction { get; }

        /// <summary>
        ///
        /// </summary>
        IBindable<double> TimeRange { get; }

        /// <summary>
        /// The algorithm which controls <see cref="HitObject"/> positions and sizes.
        /// </summary>
        ITauScrollAlgorithm Algorithm { get; }
    }
}
