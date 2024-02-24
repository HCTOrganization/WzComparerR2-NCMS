﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WzComparerR2.CharaSim
{
    public enum GearPropType
    {
        //普通装备属性
        incSTR = 1,
        incSTRr,
        incDEX,
        incDEXr,
        incINT,
        incINTr,
        incLUK,
        incLUKr,
        incAllStat,
        incAllStat_incMHP25,
        incAllStat_incMHP50_incMMP50,
        incMHP_incMMP,
        incMHPr_incMMPr,
        incMHP,
        incMHPr,
        incMMP,
        incMMPr,
        incMDF,
        incARC,
        incAUT,
        incPAD_incMAD,
        incPAD,
        incMAD,
        incAD,
        incPDD_incMDD,
        incPDD,
        incMDD,
        incACC_incEVA,
        incACC,
        incEVA,
        incSpeed,
        incJump,
        incCraft,
        knockback,
        incPVPDamage,
        bdR,
        incBDR,
        imdR,
        incIMDR,
        damR,
        nbdR,
        statR,
        incCHUC,

        //潜能属性
        incPADr = 100,
        incMADr,
        incPDDr,
        incMDDr,
        incACCr,
        incEVAr,
        incCr,
        incCDr,
        incDAMr,
        RecoveryHP,
        RecoveryMP,
        face,
        prop,
        time,
        HP,
        MP,
        attackType,
        ignoreTargetDEF,
        ignoreDAM,
        ignoreDAMr,
        DAMreflect,
        mpconReduce,
        mpRestore,
        incMesoProp,
        incRewardProp,
        incAllskill,
        RecoveryUP,
        boss,
        level,
        incTerR,
        incAsrR,
        incEXPr,
        reduceCooltime,
        incCriticaldamageMax,
        incCriticaldamageMin,
        @sealed,
        incSTRlv,
        incDEXlv,
        incINTlv,
        incLUKlv,
        incMaxDamage,
        incMHPlv,
        incPADlv,
        incMADlv,
        incCriticaldamage,

        Option,
        OptionToMob,
        activeSkill,
        bonusByTime,

        //特殊装备属性
        attackSpeed = 200,
        tuc,
        setItemID,
        durability,
        reqCraft,
        cash,
        royalSpecial,
        masterSpecial,
        reduceReq,

        //技能特有属性
        mastery = 300,
        //criticaldamageMin,
        //criticaldamageMax,
        criticaldamage,
        epad,
        emad,
        epdd,
        emdd,
        emhp,
        emmp,
        smartpad,
        smartacc,
        smarteva,

        //装备特有属性
        reqLevel = 1000,
        reqSTR,
        reqDEX,
        reqINT,
        reqLUK,
        reqJob,
        reqPOP,
        reqSpecJob,
        reqWeekDay, //要求日子
        grade,

        only = 1100,
        //notSale,
        //dropBlock,
        tradeBlock,
        accountSharable,
        onlyEquip,
        tradeAvailable,
        equipTradeBlock,
        sharableOnce,
        notExtend,
        epicItem,
        charismaEXP,
        senseEXP,
        insightEXP,
        willEXP,
        craftEXP,
        charmEXP,
        cashForceCharmExp,
        accountShareTag,
        noPotential,
        fixedPotential,
        timeLimited,
        specialGrade,
        fixedGrade,
        unchangeable,
        superiorEqp,
        incPQEXPr,
        limitBreak,
        nActivatedSocket,
        jokerToSetItem,
        plusToSetItem,
        medalTag,
        ringOptionSkill,
        ringOptionSkillLv,
        abilityTimeLimited,
        blockGoldHammer,
        exceptUpgrade,
        colorvar,
        noMoveToLocker,
        onlyUpgrade,
        cantRepair,
        noPetEquipStatMoveItem,
        BTSLabel,
        BLACKPINKLabel,
        android,
        noLookChange,
        tucIgnoreForPotential,
        Etuc,
        price,
        notSale,
        scissorAmount_wz2,

        gatherTool_incSkillLevel = 2000,
        gatherTool_incSpeed,
        gatherTool_incNum,
        gatherTool_reqSkillLevel,
    }
}
