﻿using HarmonyLib;
using ModLib;
using System;
using System.Windows;
using System.Reflection;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BoostLeadership
{
    public class BoostLeadershipSubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            try
            {
                base.OnSubModuleLoad();
                Harmony.DEBUG = true;
                FileLog.Reset();
                Harmony harmony1 = new Harmony("mod.bannerlord.boostleadership");
                harmony1.PatchAll(Assembly.GetExecutingAssembly());
                FileDatabase.Initialise("BoostLeadership");
                BoostLeadershipSettings settings = FileDatabase.Get<BoostLeadershipSettings>(BoostLeadershipSettings.InstanceID);
                if (settings == null) settings = new BoostLeadershipSettings();
                SettingsDatabase.RegisterSettings(settings);
            }
            catch (Exception ex)
            {
                FileLog.Log($"Can't load BoostLeadership sub module : {ex.Message}");
                //Handle exceptions
            }
            
        }

        //protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        //{
        //    try
        //    {
        //        if (!(gameStarterObject is CampaignGameStarter))
        //            return;
        //        this.AddBehaviors(game, (CampaignGameStarter)gameStarterObject);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private void AddBehaviors(Game game, CampaignGameStarter gameInitializer)
        //{
        //    try
        //    {
        //        if (!(game.GameType is Campaign))
        //            return;
        //        gameInitializer.AddBehavior((CampaignBehaviorBase)new BoostLeadershipMobilePartyTrainingBehavior());
        //        InformationManager.DisplayMessage(new InformationMessage($"{nameof(BoostLeadershipMobilePartyTrainingBehavior)} added"));
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
    }
}
