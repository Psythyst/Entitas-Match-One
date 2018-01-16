﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class SetViewPositionSystem : ReactiveSystem<GameEntity> {

    public SetViewPositionSystem(GameContext Game) : base(Game) {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.View);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var e in entities) {
            var pos = e.position;
            e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y, 0f);
        }
    }
}
