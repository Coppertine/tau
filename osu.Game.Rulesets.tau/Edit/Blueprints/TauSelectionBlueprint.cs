using osu.Game.Rulesets.Edit;
using osu.Game.Rulesets.Tau.Objects;
using osu.Game.Rulesets.Tau.Objects.Drawables;

namespace osu.Game.Rulesets.Tau.Edit.Blueprints
{
    public abstract class TauSelectionBlueprint<T> : OverlaySelectionBlueprint
        where T : TauHitObject
    {
        protected new T HitObject => (T) DrawableObject.HitObject;

        protected TauSelectionBlueprint(DrawabletauHitObject drawableObject)
            : base(drawableObject)
        {
        }
    }
}
