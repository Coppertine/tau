using osu.Framework.Graphics;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Logging;
using osu.Game.Rulesets.Tau.Objects;
using osu.Game.Rulesets.Tau.Objects.Drawables;
using osu.Game.Rulesets.Tau.UI;
using osu.Game.Screens.Edit;
using osuTK;

namespace osu.Game.Rulesets.Tau.Edit.Blueprints.Sliders
{
    public class SliderSelectionBlueprint : TauSelectionBlueprint<Slider>
    {
        protected new DrawableSlider DrawableObject => (DrawableSlider)base.DrawableObject;
        protected readonly SliderHeadPiece SelectionHeadPiece;

        public SliderSelectionBlueprint(Slider hitObject)
            : base(hitObject)
        {
            InternalChildren = new Drawable[]
            {
                SelectionHeadPiece = new SliderHeadPiece(),
            };
        }

        protected override void Update()
        {
            base.Update();

            SelectionHeadPiece.Rotation = DrawableObject.HeadBeat.Rotation;
            // Logger.Log("HeadBeat y at " + (float)(1 - Clock.CurrentTime / DrawableObject.HeadBeat.HitObject.TimePreempt) * (TauPlayfield.BASE_SIZE.X / 2));
            SelectionHeadPiece.Position = Extensions.GetCircularPosition(-DrawableObject.HeadBeat.Box.Y, DrawableObject.HeadBeat.Rotation);
        }

        public override Vector2 ScreenSpaceSelectionPoint => DrawableObject.Position;

        public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => SelectionHeadPiece.ReceivePositionalInputAt(screenSpacePos);

        public override Quad SelectionQuad => DrawableObject.ScreenSpaceDrawQuad.AABB;
    }
}
