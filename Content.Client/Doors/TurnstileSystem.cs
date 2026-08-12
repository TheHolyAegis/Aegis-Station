using Content.Shared.Doors.Components;
using Content.Shared.Doors.Systems;
using Robust.Client.Animations;
using Robust.Client.GameObjects;

namespace Content.Client.Doors;

/// <inheritdoc/>
public sealed class TurnstileSystem : SharedTurnstileSystem
{
<<<<<<< HEAD
    [Dependency] private readonly AnimationPlayerSystem _animationPlayer = default!;
    [Dependency] private readonly SpriteSystem _sprite = default!;

    private static readonly EntProtoId ExamineArrow = "TurnstileArrow";
=======
    [Dependency] private AppearanceSystem _appearance = default!;
    [Dependency] private AnimationPlayerSystem _animation = default!;
>>>>>>> 4645e40b60 (The Respritening - Batch 1 (#44857))

    private const string AnimationKey = "Turnstile";

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TurnstileComponent, AnimationCompletedEvent>(OnAnimationCompleted);
        SubscribeLocalEvent<TurnstileComponent, ExaminedEvent>(OnExamined);
    }

    private void OnAnimationCompleted(Entity<TurnstileComponent> ent, ref AnimationCompletedEvent args)
    {
        if (args.Key != AnimationKey)
            return;

        _appearance.SetData(ent, TurnstileVisualLayers.Base, TurnstileStates.Idle);
    }

<<<<<<< HEAD
    private void OnExamined(Entity<TurnstileComponent> ent, ref ExaminedEvent args)
    {
        Spawn(ExamineArrow, new EntityCoordinates(ent, 0, 0));
    }

    protected override void PlayAnimation(EntityUid uid, string stateId)
=======
    protected override void PlayAnimation(EntityUid uid, TurnstileStates state)
>>>>>>> 4645e40b60 (The Respritening - Batch 1 (#44857))
    {
        if (!TryComp<AnimationPlayerComponent>(uid, out var animation))
            return;

        if (_animation.HasRunningAnimation(uid, AnimationKey) || !TryComp<TurnstileComponent>(uid, out var turnComp))
            return;

        var anim = new Animation
        {
            Length = turnComp.AnimationCooldown,
        };

        _animation.Play((uid, animation), anim, AnimationKey);
        _appearance.SetData(uid, TurnstileVisualLayers.Base, state);
    }
}
