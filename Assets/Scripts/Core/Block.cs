﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Block // Eden structure block
{
    public BlockType BlockType = BlockType.Air;

    public Paintings Painting = Paintings.Unpainted;

    public bool isBurns;

    public Block(BlockType type, Paintings painting)
    {
        this.BlockType = type;
        this.Painting = painting;
    }

    public Block()
    {
        this.BlockType = BlockType.Air;
        this.Painting = Paintings.Unpainted;
    }

    public Block(BlockType type)
    {
        this.BlockType = type;
        this.Painting = Paintings.Unpainted;
    }

    public bool IsSolid()
    {
        if (this.BlockType != BlockType.Air)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsTransparent()
    {
        BlockSet.BlockSettings blocksettings;

        BlockSet.Blocks.TryGetValue(this.BlockType, out blocksettings);
        if (blocksettings != null && blocksettings.isTransparent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsLiquid()
    {
        return this.BlockType == BlockType.Water || this.BlockType == BlockType.Water1_4 || this.BlockType == BlockType.Water2_4 || this.BlockType == BlockType.Water3_4;
    }

    public bool IsRamp()
    {
        BlockSet.BlockSettings blocksettings;

        BlockSet.Blocks.TryGetValue(this.BlockType, out blocksettings);
        return blocksettings != null && blocksettings.CustomBlock == 2;
    }

    public Color32 GetColor()
    {
        return PaintController.GetColor(Painting);
    }

    public bool Equals(Block obj)
    {
        if (obj.BlockType == this.BlockType && obj.Painting == this.Painting)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}