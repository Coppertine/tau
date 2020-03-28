using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using osu.Framework.Graphics.Shapes;
using osuTK;

namespace osu.Game.Rulesets.Tau.Objects.Drawables
{
    public class DrawableBarlineMajor : DrawableBarLine
    {
        /// <summary>
        /// The vertical offset of the triangles from the line tracker.
        /// </summary>
        private const float triangle_offfset = 10f;

        /// <summary>
        /// The size of the triangles.
        /// </summary>
        private const float triangle_size = 20f;

        private readonly Container triangleContainer;

        public DrawableBarlineMajor(TauBarline barLine)
            : base(barLine)
        {
            AddInternal(triangleContainer = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Children = new[]
                {
                    new EquilateralTriangle
                    {
                        Name = "Top",
                        Anchor = Anchor.TopCentre,
                        Origin = Anchor.TopCentre,
                        Position = new Vector2(0, -triangle_offfset),
                        Size = new Vector2(-triangle_size),
                        EdgeSmoothness = new Vector2(1),
                    },
                    new EquilateralTriangle
                    {
                        Name = "Bottom",
                        Anchor = Anchor.BottomCentre,
                        Origin = Anchor.TopCentre,
                        Position = new Vector2(0, triangle_offfset),
                        Size = new Vector2(triangle_size),
                        EdgeSmoothness = new Vector2(1),
                    }
                }
            });

            Tracker.Alpha = 1f;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            using (triangleContainer.BeginAbsoluteSequence(HitObject.StartTime))
                triangleContainer.FadeOut(150);
        }
    }
}
