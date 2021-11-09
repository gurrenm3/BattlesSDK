﻿using BattlesSDK.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace BattlesSDK.Api
{
    /// <summary>
    /// Parent class for all Battles mods
    /// </summary>
    public class BattlesMod : IBattlesMod
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModConfigV1 ModInfo { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IBattlesLogger Logger { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModLoader ModLoader { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual void Start()
        {
            
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual void Update()
        {
            
        }
    }
}