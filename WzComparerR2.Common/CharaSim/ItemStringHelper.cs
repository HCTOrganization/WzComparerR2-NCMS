using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WzComparerR2.CharaSim
{
    public static class ItemStringHelper
    {
        /// <summary>
        /// 获取怪物category属性对应的类型说明。
        /// </summary>
        /// <param Name="category">怪物的category属性的值。</param>
        /// <returns></returns>
        public static string GetMobCategoryName(int category)
        {
            switch (category)
            {
                case 0: return "无形态";
                case 1: return "动物型";
                case 2: return "植物型";
                case 3: return "鱼类型";
                case 4: return "爬虫类型";
                case 5: return "精灵型";
                case 6: return "恶魔型";
                case 7: return "不死型";
                case 8: return "无机物型";
                default: return null;
            }
        }

        public static string GetGearPropString(GearPropType propType, int value)
        {
            return GetGearPropString(propType, value, 0);
        }

        /// <summary>
        /// 获取GearPropType所对应的文字说明。
        /// </summary>
        /// <param Name="propType">表示装备属性枚举GearPropType。</param>
        /// <param Name="Value">表示propType属性所对应的值。</param>
        /// <returns></returns>
        public static string GetGearPropString(GearPropType propType, int value, int signFlag)
        {

            string sign;
            switch (signFlag)
            {
                default:
                case 0: //默认处理符号
                    sign = value > 0 ? "+" : null;
                    break;

                case 1: //固定加号
                    sign = "+";
                    break;

                case 2: //无特别符号
                    sign = "";
                    break;
            }
            switch (propType)
            {
                case GearPropType.incSTR: return "力量 : " + sign + value;
                case GearPropType.incSTRr: return "力量 : " + sign + value + "%";
                case GearPropType.incDEX: return "敏捷 : " + sign + value;
                case GearPropType.incDEXr: return "敏捷 : " + sign + value + "%";
                case GearPropType.incINT: return "智力 : " + sign + value;
                case GearPropType.incINTr: return "智力 : " + sign + value + "%";
                case GearPropType.incLUK: return "运气 : " + sign + value;
                case GearPropType.incLUKr: return "运气 : " + sign + value + "%";
                case GearPropType.incAllStat: return "所有属性 : " + sign + value;
                case GearPropType.incMHP: return "最大血量： " + sign + value;
                case GearPropType.incMHPr: return "最大血量： " + sign + value + "%";
                case GearPropType.incMMP: return "最大魔量： " + sign + value;
                case GearPropType.incMMPr: return "最大魔量： " + sign + value + "%";
                case GearPropType.incMDF: return "MaxDF : " + sign + value;
                case GearPropType.incPAD: return "攻击力 : " + sign + value;
                case GearPropType.incPADr: return "攻击力 : " + sign + value + "%";
                case GearPropType.incMAD: return "魔法力 : " + sign + value;
                case GearPropType.incMADr: return "魔法力 : " + sign + value + "%";
                case GearPropType.incPDD: return "防御力 : " + sign + value;
                case GearPropType.incPDDr: return "物理防御力 : " + sign + value + "%";
                case GearPropType.incMDD: return "魔法防御力 : " + sign + value;
                case GearPropType.incMDDr: return "魔法防御力 : " + sign + value + "%";
                case GearPropType.incACC: return "命中值 : " + sign + value;
                case GearPropType.incACCr: return "命中值 : " + sign + value + "%";
                case GearPropType.incEVA: return "回避值 : " + sign + value;
                case GearPropType.incEVAr: return "回避值 : " + sign + value + "%";
                case GearPropType.incSpeed: return "移动速度 : " + sign + value;
                case GearPropType.incJump: return "跳跃力 : " + sign + value;
                case GearPropType.incCraft: return "手技 : " + sign + value;
                case GearPropType.damR:
                case GearPropType.incDAMr: return "总伤害 : " + sign + value + "%";
                case GearPropType.incCr: return "爆击率 : " + sign + value + "%";
                case GearPropType.incCDr: return "爆击伤害 : " + sign + value + "%";
                case GearPropType.knockback: return "直接攻击时" + value + "的比率发生后退现象。";
                case GearPropType.incPVPDamage: return "大乱斗时追加攻击力" + sign + value;
                case GearPropType.incPQEXPr: return "组队任务经验值增加" + value + "%";
                case GearPropType.incEXPr: return "经验值增加" + value + "%";
                case GearPropType.incBDR:
                case GearPropType.bdR: return "攻击首领怪时，伤害+" + value + "%";
                case GearPropType.incIMDR:
                case GearPropType.imdR: return "无视怪物防御率：+" + value + "%";
                case GearPropType.limitBreak: return "伤害上限突破至" + ToCJKNumberExpr(value) + "。";
                case GearPropType.reduceReq: return "装备等级降低：- " + value;
                case GearPropType.nbdR: return "攻击普通怪物时，伤害+" + value + "%";

                case GearPropType.only: return value == 0 ? null : "固有道具";
                case GearPropType.tradeBlock: return value == 0 ? null : "不可交换";
                case GearPropType.equipTradeBlock: return value == 0 ? null : "装备后无法交换";
                case GearPropType.accountSharable: return value == 0 ? null : "服务器内只有我的角色之间可以移动";
                case GearPropType.onlyEquip: return value == 0 ? null : "固有装备物品";
                case GearPropType.notExtend: return value == 0 ? null : "无法延长有效时间。";
                case GearPropType.accountSharableAfterExchange: return value == 0 ? null : "可交换1次\n（交易后只能在世界内我的角色之间移动）";
                case GearPropType.tradeAvailable:
                    switch (value)
                    {
                        case 1: return " #c使用宿命剪刀，可以使物品交易1次。#";
                        case 2: return " #c使用白金宿命剪刀，可以使物品交易1次。#";
                        default: return null;
                    }
                case GearPropType.accountShareTag:
                    switch (value)
                    {
                        case 1: return " #c使用物品共享牌，可以在同一账号内的角色间移动1次。#";
                        default: return null;
                    }
                //case GearPropType.noPotential: return value == 0 ? null : "This item cannot gain Potential.";
                case GearPropType.noPotential: return value == 0 ? null : "无法设置潜能。";
                case GearPropType.fixedPotential: return value == 0 ? null : "无法重设潜能";
                case GearPropType.superiorEqp: return value == 0 ? null : "道具强化成功时，可以获得更高的效果。";
                case GearPropType.nActivatedSocket: return value == 0 ? null : "#c可以镶嵌星岩#";
                case GearPropType.jokerToSetItem: return value == 0 ? null : " #c当前装备3个以上的所有套装道具中包含的幸运物品！#";
                case GearPropType.abilityTimeLimited: return value == 0 ? null : "限期能力值";
                case GearPropType.blockGoldHammer: return value == 0 ? null : "无法使用黄金锤";
                case GearPropType.colorvar: return value == 0 ? null : "#c该装备可通过染色颜料来变更颜色.#";
                case GearPropType.cantRepair: return value == 0 ? null : "无法复原耐久度";
                case GearPropType.noLookChange: return value == 0 ? null : "无法使用神秘的铁砧";

                case GearPropType.incAllStat_incMHP25: return "全属性：" + sign + value + ", 最大血量：" + sign + (value * 25);// check once Lv 250 set comes out in GMS
                case GearPropType.incAllStat_incMHP50_incMMP50: return "全属性：" + sign + value + ", 最大血量/最大魔量：" + sign + (value * 50);
                case GearPropType.incMHP_incMMP: return "最大HP / 最大MP：" + sign + value;
                case GearPropType.incMHPr_incMMPr: return "最大HP / 最大MP：" + sign + value + "%";
                case GearPropType.incPAD_incMAD:
                case GearPropType.incAD: return "攻击力/魔力：" + sign + value;
                case GearPropType.incPDD_incMDD: return "物理/魔法防御力：" + sign + value;
                case GearPropType.incACC_incEVA: return "命中值/回避值：" + sign + value;

                case GearPropType.incARC: return "神秘之力 : " + sign + value;
                case GearPropType.incAUT: return "原初之力 : " + sign + value;

                case GearPropType.Etuc: return "可进行卓越强化。（最多：" + value + "次）";
                case GearPropType.CuttableCount: return "可使用剪刀：" + value + "次";
                default: return null;
            }
        }


        public static string GetGearPropDiffString(GearPropType propType, int value, int standardValue)
        {
            var propStr = GetGearPropString(propType, value);
            if (value > standardValue)
            {
                string subfix = null;
                switch (propType)
                {
                    case GearPropType.incSTR:
                    case GearPropType.incDEX:
                    case GearPropType.incINT:
                    case GearPropType.incLUK:
                    case GearPropType.incMHP:
                    case GearPropType.incMMP:
                    case GearPropType.incMDF:
                    case GearPropType.incARC:
                    case GearPropType.incAUT:
                    case GearPropType.incPAD:
                    case GearPropType.incMAD:
                    case GearPropType.incPDD:
                    case GearPropType.incMDD:
                    case GearPropType.incSpeed:
                    case GearPropType.incJump:
                        subfix = $"({standardValue} #$+{value - standardValue}#)"; break;

                    case GearPropType.bdR:
                    case GearPropType.incBDR:
                    case GearPropType.imdR:
                    case GearPropType.incIMDR:
                    case GearPropType.damR:
                    case GearPropType.incDAMr:
                    case GearPropType.statR:
                        subfix = $"({standardValue}% #$+{value - standardValue}%#)"; break;
                }
                propStr = "#$" + propStr + "# " + subfix;
            }
            return propStr;
        }

        /// <summary>
        /// 获取gearGrade所对应的字符串。
        /// </summary>
        /// <param Name="rank">表示装备的潜能等级GearGrade。</param>
        /// <returns></returns>
        public static string GetGearGradeString(GearGrade rank)
        {
            switch (rank)
            {
                case GearGrade.C: return "C级(一般物品)";
                case GearGrade.B: return "B级(高级物品)";
                case GearGrade.A: return "A级(史诗物品)";
                case GearGrade.S: return "S级(传说物品)";
                case GearGrade.SS: return "SS级(传说极品)";
                case GearGrade.Special: return "(特殊物品)";
                default: return null;
            }
        }

        /// <summary>
        /// 获取gearType所对应的字符串。
        /// </summary>
        /// <param Name="Type">表示装备类型GearType。</param>
        /// <returns></returns>
        public static string GetGearTypeString(GearType type)
        {
            switch (type)
            {
                case GearType.body: return "纸娃娃(身体)";
                case GearType.head: return "纸娃娃(头部)";
                case GearType.face:
                case GearType.face2: return "纸娃娃(脸型)";
                case GearType.hair:
                case GearType.hair2:
                case GearType.hair3: return "纸娃娃(发型)";
                case GearType.faceAccessory: return "脸饰";
                case GearType.eyeAccessory: return "眼饰";
                case GearType.earrings: return "耳环";
                case GearType.pendant: return "坠子";
                case GearType.belt: return "腰带";
                case GearType.medal: return "勋章";
                case GearType.shoulderPad: return "肩饰";
                case GearType.cap: return "帽子";
                case GearType.cape: return "披风";
                case GearType.coat: return "上衣";
                case GearType.dragonMask: return "龙神帽子";
                case GearType.dragonPendant: return "龙神吊坠";
                case GearType.dragonWings: return "龙神翅膀";
                case GearType.dragonTail: return "龙神尾巴";
                case GearType.glove: return "手套";
                case GearType.longcoat: return "套服";
                case GearType.machineEngine: return "机甲引擎";
                case GearType.machineArms: return "机甲机械臂";
                case GearType.machineLegs: return "机甲机械腿";
                case GearType.machineBody: return "机甲机身材质";
                case GearType.machineTransistors: return "机甲晶体管";
                case GearType.pants: return "裤/裙";
                case GearType.ring: return "戒指";
                case GearType.shield: return "盾牌";
                case GearType.shoes: return "鞋子";
                case GearType.shiningRod: return "双头杖";
                case GearType.soulShooter: return "灵魂手铳";
                case GearType.ohSword: return "单手剑";
                case GearType.ohAxe: return "单手斧";
                case GearType.ohBlunt: return "单手钝器";
                case GearType.dagger: return "短刀";
                case GearType.katara: return "刀";
                case GearType.magicArrow: return "魔法箭矢";
                case GearType.card: return "卡片";
                case GearType.box: return "宝盒";
                case GearType.orb: return "宝珠";
                case GearType.novaMarrow: return "龙之精髓";
                case GearType.soulBangle: return "灵魂手镯";
                case GearType.mailin: return "麦林";
                case GearType.cane: return "手杖";
                case GearType.wand: return "短杖";
                case GearType.staff: return "长杖";
                case GearType.thSword: return "双手剑";
                case GearType.thAxe: return "双手斧";
                case GearType.thBlunt: return "双手钝器";
                case GearType.spear: return "枪";
                case GearType.polearm: return "矛";
                case GearType.bow: return "弓";
                case GearType.crossbow: return "弩";
                case GearType.throwingGlove: return "拳套";
                case GearType.knuckle: return "指节";
                case GearType.gun: return "短枪";
                case GearType.android: return "智能机器人";
                case GearType.machineHeart: return "机械心脏";
                case GearType.pickaxe: return "采矿工具";
                case GearType.shovel: return "采药工具";
                case GearType.pocket: return "口袋物品";
                case GearType.dualBow: return "双弩枪";
                case GearType.handCannon: return "手持火炮";
                case GearType.badge: return "徽章";
                case GearType.emblem: return "纹章";
                case GearType.soulShield: return "灵魂盾";
                case GearType.demonShield: return "精气盾";
                case GearType.totem: return "图腾";
                case GearType.petEquip: return "宠物装备";
                case GearType.taming:
                case GearType.taming2:
                case GearType.taming3:
                case GearType.tamingChair: return "骑兽";
                case GearType.saddle: return "鞍子";
                case GearType.katana: return "武士刀";
                case GearType.fan: return "折扇";
                case GearType.swordZB: return "大剑";
                case GearType.swordZL: return "太刀";
                case GearType.weapon: return "武器";
                case GearType.subWeapon: return "辅助武器";
                case GearType.heroMedal: return "吊坠";
                case GearType.rosario: return "念珠";
                case GearType.chain: return "铁链";
                case GearType.book1:
                case GearType.book2:
                case GearType.book3: return "魔导书";
                case GearType.bowMasterFeather: return "箭羽";
                case GearType.crossBowThimble: return "扳指";
                case GearType.shadowerSheath: return "短剑剑鞘";
                case GearType.nightLordPoutch: return "护身符";
                case GearType.viperWristband: return "手腕护带";
                case GearType.captainSight: return "瞄准器";
                case GearType.cannonGunPowder:
                case GearType.cannonGunPowder2: return "火药桶";
                case GearType.aranPendulum: return "砝码";
                case GearType.evanPaper: return "文件";
                case GearType.battlemageBall: return "魔法球";
                case GearType.wildHunterArrowHead: return "箭轴";
                case GearType.cygnusGem: return "宝石";
                case GearType.controller: return "控制器";
                case GearType.foxPearl: return "狐狸珠";
                case GearType.chess: return "棋子";
                case GearType.powerSource: return "能源";

                case GearType.energySword: return "能量剑";
                case GearType.desperado: return "亡命剑";
                case GearType.memorialStaff: return "记忆长杖";
                case GearType.magicStick: return "魔法棒";
                case GearType.leaf:
                case GearType.leaf2: return "飞越";
                case GearType.boxingClaw: return "拳爪";
                case GearType.kodachi:
                case GearType.kodachi2: return "小太刀";
                case GearType.espLimiter: return "ESP限制器";

                case GearType.GauntletBuster: return "机甲手枪";
                case GearType.ExplosivePill: return "装弹";

                case GearType.chain2: return "锁链";
                case GearType.magicGauntlet: return "魔力手套";
                case GearType.transmitter: return "武器传送装置";
                case GearType.magicWing: return "魔法之翼";
                case GearType.pathOfAbyss: return "深渊精气珠";

                case GearType.relic: return "遗物";
                case GearType.ancientBow: return "远古弓";

                case GearType.handFan: return "扇子";
                case GearType.fanTassel: return "扇坠";

                case GearType.tuner: return "调谐器";
                case GearType.bracelet: return "手链";

                case GearType.boxingCannon: return "拳封";
                case GearType.boxingSky: return "拳天";

                case GearType.breathShooter: return "龙息臂箭";
                case GearType.weaponBelt: return "武器腰带";

                case GearType.ornament: return "饰品";

                case GearType.chakram: return "环刃";
                case GearType.hexSeeker: return "索魂器";
                default: return null;
            }
        }

        /// <summary>
        /// 获取武器攻击速度所对应的字符串。
        /// </summary>
        /// <param Name="attackSpeed">表示武器的攻击速度，通常为2~9的数字。</param>
        /// <returns></returns>
        public static string GetAttackSpeedString(int attackSpeed)
        {
            switch (attackSpeed)
            {
                case 2:
                case 3: return "极快";
                case 4:
                case 5: return "快";
                case 6: return "普通";
                case 7:
                case 8: return "缓慢";
                case 9: return "较慢";
                default:
                    return attackSpeed.ToString();
            }
        }

        /// <summary>
        /// 获取套装装备类型的字符串。
        /// </summary>
        /// <param Name="Type">表示套装装备类型的GearType。</param>
        /// <returns></returns>
        public static string GetSetItemGearTypeString(GearType type)
        {
            return GetGearTypeString(type);
        }

        /// <summary>
        /// 获取装备额外职业要求说明的字符串。
        /// </summary>
        /// <param Name="Type">表示装备类型的GearType。</param>
        /// <returns></returns>
        public static string GetExtraJobReqString(GearType type)
        {
            switch (type)
            {
                //0xxx
                case GearType.heroMedal: return "英雄职业群可穿戴装备";
                case GearType.rosario: return "圣骑士职业群可穿戴装备";
                case GearType.chain: return "黑骑士职业群可穿戴装备";
                case GearType.book1: return "火毒系列魔法师可穿戴装备";
                case GearType.book2: return "冰雷系列魔法师可穿戴装备";
                case GearType.book3: return "主教系列魔法师可穿戴装备";
                case GearType.bowMasterFeather: return "神射手职业群可穿戴装备";
                case GearType.crossBowThimble: return "箭神职业群可穿戴装备";
                case GearType.shadowerSheath: return "侠盗职业群可穿戴装备";
                case GearType.nightLordPoutch: return "隐士职业群可穿戴装备";
                case GearType.katara: return "暗影双刀可穿戴装备";
                case GearType.viperWristband: return "冲锋队长职业群可穿戴装备";
                case GearType.captainSight: return "船长职业群可穿戴装备";
                case GearType.cannonGunPowder:
                case GearType.cannonGunPowder2: return "火炮手职业群可穿戴装备";
                case GearType.box:
                case GearType.boxingClaw: return "龙的传人可穿戴装备";
                case GearType.relic: return "古迹猎人职业群可穿戴装备";

                //1xxx
                case GearType.cygnusGem: return "希纳斯骑士团可穿戴装备";

                //2xxx
                case GearType.aranPendulum: return GetExtraJobReqString(21);
                case GearType.dragonMask:
                case GearType.dragonPendant:
                case GearType.dragonWings:
                case GearType.dragonTail:
                case GearType.evanPaper: return GetExtraJobReqString(22);
                case GearType.magicArrow: return GetExtraJobReqString(23);
                case GearType.card: return GetExtraJobReqString(24);
                case GearType.foxPearl: return GetExtraJobReqString(25);
                case GearType.orb:
                case GearType.shiningRod: return GetExtraJobReqString(27);

                //3xxx
                case GearType.demonShield: return GetExtraJobReqString(31);
                case GearType.desperado: return "恶魔复仇者可穿戴装备";
                case GearType.battlemageBall: return "唤灵斗师职业群可穿戴装备";
                case GearType.wildHunterArrowHead: return "豹弩游侠职业群可穿戴装备";
                case GearType.machineEngine:
                case GearType.machineArms:
                case GearType.machineLegs:
                case GearType.machineBody:
                case GearType.machineTransistors:
                case GearType.mailin: return "机械师可穿戴装备";
                case GearType.controller:
                case GearType.powerSource:
                case GearType.energySword: return GetExtraJobReqString(36);
                case GearType.GauntletBuster:
                case GearType.ExplosivePill: return GetExtraJobReqString(37);

                //4xxx
                case GearType.katana:
                case GearType.kodachi:
                case GearType.kodachi2: return GetExtraJobReqString(41);
                case GearType.fan: return "阴阳师可穿戴装备";

                //5xxx
                case GearType.soulShield: return "米哈尔可穿戴装备";

                //6xxx
                case GearType.novaMarrow: return GetExtraJobReqString(61);
                case GearType.weaponBelt:
                case GearType.breathShooter: return GetExtraJobReqString(63);
                case GearType.chain2:
                case GearType.transmitter: return GetExtraJobReqString(64);
                case GearType.soulBangle:
                case GearType.soulShooter: return GetExtraJobReqString(65);

                //10xxx
                case GearType.swordZB:
                case GearType.swordZL: return GetExtraJobReqString(101);

                case GearType.magicStick: return GetExtraJobReqString(112);
                case GearType.leaf:
                case GearType.leaf2:
                case GearType.memorialStaff: return GetExtraJobReqString(172);

                case GearType.espLimiter:
                case GearType.chess: return GetExtraJobReqString(142);

                case GearType.magicGauntlet:
                case GearType.magicWing: return GetExtraJobReqString(152);

                case GearType.pathOfAbyss: return GetExtraJobReqString(155);
                case GearType.handFan:
                case GearType.fanTassel: return GetExtraJobReqString(164);

                case GearType.tuner:
                case GearType.bracelet: return GetExtraJobReqString(151);

                case GearType.boxingCannon:
                case GearType.boxingSky: return GetExtraJobReqString(175);

                case GearType.ornament: return GetExtraJobReqString(162);
                default: return null;
            }
        }

        /// <summary>
        /// 获取装备额外职业要求说明的字符串。
        /// </summary>
        /// <param Name="specJob">表示装备属性的reqSpecJob的值。</param>
        /// <returns></returns>
        public static string GetExtraJobReqString(int specJob)
        {
            switch (specJob)
            {
                case 21: return "战神可穿戴装备";
                case 22: return "龙神职业群可穿戴装备";
                case 23: return "双弩精灵可穿戴装备";
                case 24: return "幻影可穿戴装备";
                case 25: return "隐月可穿戴装备";
                case 27: return "夜光法师可穿戴装备";
                case 31: return "恶魔猎手可穿戴装备";
                case 36: return "尖兵可穿戴装备";
                case 37: return "爆破手可使用";
                case 41: return "剑豪可穿戴装备";
                case 42: return "阴阳师可穿戴装备";
                case 51: return "米哈尔可穿戴装备";
                case 61: return "狂龙战士可穿戴装备";
                case 63: return "炼狱黑客可穿戴装备";
                case 64: return "魔链影士可穿戴装备";
                case 65: return "爆莉萌天使可穿戴装备";
                case 99: return "小白狐可穿戴装备";
                case 101: return "神之子可穿戴装备";
                case 112: return "林之灵可穿戴装备";
                case 142: return "超能力者可穿戴装备";
                case 151: return "御剑骑士可穿戴装备";
                case 152: return "圣晶使徒可穿戴装备";
                case 154: return "飞刃沙士可穿戴装备";
                case 155: return "影魂异人可穿戴装备";
                case 162: return "元素师可穿戴装备";
                case 164: return "虎影可穿戴装备";
                case 172: return "琳可穿戴装备";
                case 175: return "墨玄可穿戴装备";
                default: return null;
            }
        }

        public static string GetItemPropString(ItemPropType propType, int value)
        {
            switch (propType)
            {
                case ItemPropType.tradeBlock:
                    return GetGearPropString(GearPropType.tradeBlock, value);
                case ItemPropType.useTradeBlock:
                    return value == 0 ? null : "使用後交換不可";
                case ItemPropType.tradeAvailable:
                    return GetGearPropString(GearPropType.tradeAvailable, value);
                case ItemPropType.only:
                    return GetGearPropString(GearPropType.only, value);
                case ItemPropType.accountSharable:
                    return GetGearPropString(GearPropType.accountSharable, value);
                case ItemPropType.sharableOnce:
                    return GetGearPropString(GearPropType.sharableOnce, value);
                case ItemPropType.accountSharableAfterExchange:
                    return GetGearPropString(GearPropType.accountSharableAfterExchange, value);
                case ItemPropType.exchangeableOnce:
                    return value == 0 ? null : "1回交換可能 (取引後交換不可)";
                case ItemPropType.quest:
                    return value == 0 ? null : "クエストアイテム";
                case ItemPropType.pquest:
                    return value == 0 ? null : "パーティクエストアイテム";
                case ItemPropType.permanent:
                    return value == 0 ? null : "魔法の時間が終わらないミラクルペットです。";
                case ItemPropType.multiPet:
                    // return value == 0 ? null : "マルチペット(他のペットと最大3個重複使用可能)";
                    return value == 0 ? "" : "";
                default:
                    return null;
            }
        }

        public static string GetItemCoreSpecString(ItemCoreSpecType coreSpecType, int value, string desc)
        {
            bool hasCoda = false;
            if (desc?.Length > 0)
            {
                char lastCharacter = desc.Last();
                hasCoda = lastCharacter >= '가' && lastCharacter <= '힣' && (lastCharacter - '가') % 28 != 0;
            }
            switch (coreSpecType)
            {
                case ItemCoreSpecType.Ctrl_mobLv:
                    return value == 0 ? null : "Monster Level " + "+" + value;
                case ItemCoreSpecType.Ctrl_mobHPRate:
                    return value == 0 ? null : "Monster HP " + "+" + value + "%";
                case ItemCoreSpecType.Ctrl_mobRate:
                    return value == 0 ? null : "Monster Population " + "+" + value + "%";
                case ItemCoreSpecType.Ctrl_mobRateSpecial:
                    return value == 0 ? null : "Monster Population " + "+" + value + "%";
                case ItemCoreSpecType.Ctrl_change_Mob:
                    return desc == null ? null : "Change monster skins for " + desc;
                case ItemCoreSpecType.Ctrl_change_BGM:
                    return desc == null ? null : "Change music for " + desc;
                case ItemCoreSpecType.Ctrl_change_BackGrnd:
                    return desc == null ? null : "Change background image for " + desc;
                case ItemCoreSpecType.Ctrl_partyExp:
                    return value == 0 ? null : "Party EXP " + "+" + value + "%";
                case ItemCoreSpecType.Ctrl_partyExpSpecial:
                    return value == 0 ? null : "Party EXP " + "+" + value + "%";
                case ItemCoreSpecType.Ctrl_addMob:
                    return value == 0 || desc == null ? null : desc + ", Link " + value + " added to area";
                case ItemCoreSpecType.Ctrl_dropRate:
                    return value == 0 ? null : "Drop Rate " + "+" + value + "%";
                case ItemCoreSpecType.Ctrl_dropRateSpecial:
                    return value == 0 ? null : "Drop Rate " + "+" + value + "%";
                case ItemCoreSpecType.Ctrl_dropRate_Herb:
                    return value == 0 ? null : "Herb Drop Rate " + "+" + value + "%";
                case ItemCoreSpecType.Ctrl_dropRate_Mineral:
                    return value == 0 ? null : "Mineral Drop Rate " + "+" + value + "%";
                case ItemCoreSpecType.Ctrl_dropRareEquip:
                    return value == 0 ? null : "Rare Equipment Drop";
                case ItemCoreSpecType.Ctrl_reward:
                case ItemCoreSpecType.Ctrl_addMission:
                    return desc;
                default:
                    return null;
            }
        }

        public static string GetSkillReqAmount(int skillID, int reqAmount)
        {
            switch (skillID / 10000)
            {
                case 11200: return "[必要なポポSP: " + reqAmount + "]";
                case 11210: return "[必要なライSP: " + reqAmount + "]";
                case 11211: return "[必要なエカSP: " + reqAmount + "]";
                case 11212: return "[必要なアルSP: " + reqAmount + "]";
                default: return "[必要な??SP: " + reqAmount + "]";
            }
        }

        public static string GetJobName(int jobCode)
        {
            switch (jobCode)
            {
                case 0: return "初心者";
                case 100: return "ファイター";
                case 110: return "ソードマン";
                case 111: return "ナイト";
                case 112: return "ヒーロー";
                case 114: return "ヒーロー(6次)";
                case 120: return "ページ";
                case 121: return "クルセイダー";
                case 122: return "パラディン";
                case 124: return "パラディン(6次)";
                case 130: return "スピアマン";
                case 131: return "バーサーカー";
                case 132: return "ダークナイト";
                case 134: return "ダークナイト(6次)";
                case 200: return "マジシャン";
                case 210: return "ウィザード(火・毒)";
                case 211: return "メイジ(火・毒)";
                case 212: return "アークメイジ(火・毒)";
                case 214: return "アークメイジ(火・毒)(6次)";
                case 220: return "ウィザード(氷・雷)";
                case 221: return "メイジ(氷・雷)";
                case 222: return "アークメイジ(氷・雷)";
                case 224: return "アークメイジ(氷・雷)(6次)";
                case 230: return "クレリック";
                case 231: return "プリースト";
                case 232: return "ビショップ";
                case 234: return "ビショップ(6次)";
                case 300: return "弓使い";
                case 301: return "弓使い";
                case 310: return "ハンター";
                case 311: return "レンジャー";
                case 312: return "ボウマスター";
                case 314: return "ボウマスター(6次)";
                case 320: return "クロスボウマン";
                case 321: return "スナイパー";
                case 322: return "クロスボウマスター";
                case 324: return "クロスボウマスター(6次)";
                case 330: return "エンシェントアーチャー";
                case 331: return "チェイサー";
                case 332: return "パスファインダー";
                case 333: return "パスファインダー(5次)";
                case 334: return "パスファインダー(6次)";
                case 400: return "ローグ";
                case 410: return "アサシン";
                case 411: return "ハーミット";
                case 412: return "ナイトロード";
                case 414: return "ナイトロード(6次)";
                case 420: return "シーフ";
                case 421: return "マスターシーフ";
                case 422: return "シャドー";
                case 424: return "シャドー(6次)";
                case 430: return "セミデュアル";
                case 431: return "デュアル";
                case 432: return "デュアルマスター";
                case 433: return "スラッシャー";
                case 434: return "デュアルブレイド";
                case 436: return "デュアルブレイド(6次)";
                case 500: return "海賊";
                case 501: return "海賊(キャノン)";
                case 508: return "ジェット(1次)";
                case 510: return "インファイター";
                case 511: return "バッカニア";
                case 512: return "バイパー";
                case 514: return "バイパー(6次)";
                case 520: return "ガンスリンガー";
                case 521: return "ヴァイキング";
                case 522: return "キャプテン";
                case 524: return "キャプテン(6次)";
                case 530: return "キャノンシューター";
                case 531: return "キャノンブラスター";
                case 532: return "キャノンマスター";
                case 534: return "キャノンマスター(6次)";
                case 570: return "ジェット(2次)";
                case 571: return "ジェット(3次)";
                case 572: return "ジェット(4次)";

                case 800: 
                case 900: return "運用者";

                case 1000: return "ノーブレス";
                case 1100: return "ソウルマスター(1次)";
                case 1110: return "ソウルマスター(2次)";
                case 1111: return "ソウルマスター(3次)";
                case 1112: return "ソウルマスター(4次)";
                case 1114: return "ソウルマスター((6次)";
                case 1200: return "フレイムウィザード(1次)";
                case 1210: return "フレイムウィザード(2次)";
                case 1211: return "フレイムウィザード(3次)";
                case 1212: return "フレイムウィザード(4次)";
                case 1214: return "フレイムウィザード(6次)";
                case 1300: return "ウインドシューター(1次)";
                case 1310: return "ウインドシューター(2次)";
                case 1311: return "ウインドシューター(3次)";
                case 1312: return "ウィンドシューター(4次)";
                case 1314: return "ウィンドシューター(6次)";
                case 1400: return "ナイトウォーカー(1次)";
                case 1410: return "ナイトウォーカー(2次)";
                case 1411: return "ナイトウォーカー(3次)";
                case 1412: return "ナイトウォーカー(4次)";
                case 1414: return "ナイトウォーカー(6次)";
                case 1500: return "ストライカー(1次)";
                case 1510: return "ストライカー(2次)";
                case 1511: return "ストライカー(3次)";
                case 1512: return "ストライカー(4次)";
                case 1514: return "ストライカー(6次)";


                case 2000: return "アラン";
                case 2001: return "エヴァン";
                case 2002: return "メルセデス";
                case 2003: return "ファントム";
                case 2004: return "ルミナス";
                case 2005: return "隠月";
                case 2100: return "アラン(1次)";
                case 2110: return "アラン(2次)";
                case 2111: return "アラン(3次)";
                case 2112: return "アラン(4次)";
                case 2114: return "アラン(6次)";
                case 2200:
                case 2210: return "エヴァン(1次)";
                case 2211:
                case 2212:
                case 2213: return "エヴァン(2次)";
                case 2214:
                case 2215:
                case 2216: return "エヴァン(3次)";
                case 2217:
                case 2218: return "エヴァン(4次)";
                case 2220: return "エヴァン(6次)";
                case 2300: return "メルセデス(1次)";
                case 2310: return "メルセデス(2次)";
                case 2311: return "メルセデス(3次)";
                case 2312: return "メルセデス(4次)";
                case 2314: return "メルセデス(6次)";
                case 2400: return "ファントム(1次)";
                case 2410: return "ファントム(2次)";
                case 2411: return "ファントム(3次)";
                case 2412: return "ファントム(4次)";
                case 2414: return "ファントム(6次)";
                case 2500: return "隠月(1次)";
                case 2510: return "隠月(2次)";
                case 2511: return "隠月(3次)";
                case 2512: return "隠月(4次)";
                case 2514: return "隠月(6次)";
                case 2700: return "ルミナス(1次)";
                case 2710: return "ルミナス(2次)";
                case 2711: return "ルミナス(3次)";
                case 2712: return "ルミナス(4次)";
                case 2714: return "ルミナス(6次)";


                case 3000: return "市民";
                case 3001: return "デーモン";
                case 3100: return "デーモンスレイヤー(1次)";
                case 3110: return "デーモンスレイヤー(2次)";
                case 3111: return "デーモンスレイヤー(3次)";
                case 3112: return "デーモンスレイヤー(4次)";
                case 3114: return "デーモンスレイヤー(6次)";
                case 3101: return "デーモンアヴェンジャー(1次)";
                case 3120: return "デーモンアヴェンジャー(2次)";
                case 3121: return "デーモンアヴェンジャー(3次)";
                case 3122: return "デーモンアヴェンジャー(4次)";
                case 3124: return "デーモンアヴェンジャー(6次)";
                case 3200: return "バトルメイジ(1次)";
                case 3210: return "バトルメイジ(2次)";
                case 3211: return "バトルメイジ(3次)";
                case 3212: return "バトルメイジ(4次)";
                case 3214: return "バトルメイジ(6次)";
                case 3300: return "ワイルドハンター(1次)";
                case 3310: return "ワイルドハンター(2次)";
                case 3311: return "ワイルドハンター(3次)";
                case 3312: return "ワイルドハンター(4次)";
                case 3314: return "ワイルドハンター(6次)";
                case 3500: return "メカニック(1次)";
                case 3510: return "メカニック(2次)";
                case 3511: return "メカニック(3次)";
                case 3512: return "メカニック(4次)";
                case 3514: return "メカニック(6次)";
                case 3002: return "ゼノン";
                case 3600: return "ゼノン(1次)";
                case 3610: return "ゼノン(2次)";
                case 3611: return "ゼノン(3次)";
                case 3612: return "ゼノン(4次)";
                case 3614: return "ゼノン(6次)";
                case 3700: return "ブラスター(1次)";
                case 3710: return "ブラスター(2次)";
                case 3711: return "ブラスター(3次)";
                case 3712: return "ブラスター(4次)";
                case 3714: return "ブラスター(6次)";

                case 4001: return "ハヤト";
                case 4002: return "カンナ";
                case 4100: return "ハヤト(1次)";
                case 4110: return "ハヤト(2次)";
                case 4111: return "ハヤト(3次)";
                case 4112: return "ハヤト(4次)";
                case 4114: return "ハヤト(6次)";
                case 4200: return "カンナ(1次)";
                case 4210: return "カンナ(2次)";
                case 4211: return "カンナ(3次)";
                case 4212: return "カンナ(4次)";
                case 4216: return "カンナ(6次)";


                case 5000: return "ミハエル";
                case 5100: return "ミハエル(1次)";
                case 5110: return "ミハエル(2次)";
                case 5111: return "ミハエル(3次)";
                case 5112: return "ミハエル(4次)";
                case 5114: return "ミハエル(6次)";


                case 6000: return "カイザー";
                case 6001: return "エンジェリックバスター";
                case 6002: return "カデナ";
                case 6003: return "カイン";
                case 6100: return "カイザー(1次)";
                case 6110: return "カイザー(2次)";
                case 6111: return "カイザー(3次)";
                case 6112: return "カイザー(4次)";
                case 6114: return "カイザー(6次)";
                case 6300: return "カイン(1次)";
                case 6310: return "カイン(2次)";
                case 6311: return "カイン(3次)";
                case 6312: return "カイン(4次)";
                case 6314: return "カイン(6次)";
                case 6400: return "カデナ(1次)";
                case 6410: return "カデナ(2次)";
                case 6411: return "カデナ(3次)";
                case 6412: return "カデナ(4次)";
                case 6414: return "カデナ(6次)";
                case 6500: return "エンジェリックバスター(1次)";
                case 6510: return "エンジェリックバスター(2次)";
                case 6511: return "エンジェリックバスター(3次)";
                case 6512: return "エンジェリックバスター(4次)";
                case 6514: return "エンジェリックバスター(6次)";

                case 7000: return "アビリティ";
                case 7100: return "ユニオン";
                case 7200: return "モンスターライフ";


                case 9100: return "ギルド";
                case 9200:
                case 9201:
                case 9202:
                case 9203:
                case 9204: return "専業技術";

                case 10000: return "ゼロ";
                case 10100: return "ゼロ(1次)";
                case 10110: return "ゼロ(2次)";
                case 10111: return "ゼロ(3次)";
                case 10112: return "ゼロ(4次)";
                case 10114: return "ゼロ(6次)";

                case 11000: return "ビーストテイマー";
                case 11200: return "ビーストテイマー(ポポ)";
                case 11210: return "ビーストテイマー(ライ)";
                case 11211: return "ビーストテイマー(エカ)";
                case 11212: return "ビーストテイマー(アル)";

                case 13000: return "ピンクビーン";
                case 13001: return "イェティ";
                case 13100: return "ピンクビーン";
                case 13500: return "イェティ";

                case 14000: return "キネシス";
                case 14200: return "キネシス(1次)";
                case 14210: return "キネシス(2次)";
                case 14211: return "キネシス(3次)";
                case 14212: return "キネシス(4次)";
                case 14213: return "キネシス(5次)";
                case 14214: return "キネシス(6次)";

                case 15000: return "イリウム";
                case 15001: return "アーク";
                case 15002: return "アデル";
                case 15003: return "カーリー";
                case 15100: return "アデル(1次)";
                case 15110: return "アデル(2次)";
                case 15111: return "アデル(3次)";
                case 15112: return "アデル(4次)";
                case 15114: return "アデル(6次)";
                case 15200: return "イリウム(1次)";
                case 15210: return "イリウム(2次)";
                case 15211: return "イリウム(3次)";
                case 15212: return "イリウム(4次)";
                case 15214: return "イリウム(6次)";
                case 15400: return "カーリー(1次)";
                case 15410: return "カーリー(2次)";
                case 15411: return "カーリー(3次)";
                case 15412: return "カーリー(4次)";
                case 15414: return "カーリー(6次)";
                case 15500: return "アーク(1次)";
                case 15510: return "アーク(2次)";
                case 15511: return "アーク(3次)";
                case 15512: return "アーク(4次)";
                case 15514: return "アーク(6次)";

                case 16000: return "アニマ盗賊";
                case 16001: return "ララ";
                case 16200: return "ララ(1次)";
                case 16210: return "ララ(2次)";
                case 16211: return "ララ(3次)";
                case 16212: return "ララ(4次)";
                case 16214: return "ララ(6次)";
                case 16400: return "虎影(1次)";
                case 16410: return "虎影(2次)";
                case 16411: return "虎影(3次)";
                case 16412: return "虎影(4次)";
                case 16414: return "虎影(6次)";

                case 17000: return "墨玄";
                case 17001: return "リン";
                case 17200: return "リン(1次)";
                case 17210: return "リン(2次)";
                case 17211: return "リン(3次)";
                case 17212: return "リン(4次)";
                case 17214: return "リン(6次)";
                case 17500: return "墨玄(1次)";
                case 17510: return "墨玄(2次)";
                case 17511: return "墨玄(3次)";
                case 17512: return "墨玄(4次)";
                case 17514: return "墨玄(6次)";

                case 40000: return "5次";
                case 40001: return "5次(戦士)";
                case 40002: return "5次(魔法使い)";
                case 40003: return "5次(弓使い)";
                case 40004: return "5次(盗賊)";
                case 40005: return "5次(海賊)";


                case 50000: return "6次";
                case 50006: return "6次(強化コア)";
                case 50007: return "6次(ヘキサスタット)";
            }
            return null;
        }

        private static string ToCJKNumberExpr(int value)
        {
            var sb = new StringBuilder(16);
            bool firstPart = true;
            if (value < 0)
            {
                sb.Append("-");
                value = -value; // just ignore the exception -2147483648
            }
            if (value >= 1_0000_0000)
            {
                int part = value / 1_0000_0000;
                sb.AppendFormat("{0}亿", part); // Korean: 억, TradChinese+Japanese: 億, SimpChinese: 亿
                value -= part * 1_0000_0000;
                firstPart = false;
            }
            if (value >= 1_0000)
            {
                int part = value / 1_0000;
                sb.Append(firstPart ? null : " ");
                sb.AppendFormat("{0}万", part); // Korean: 만, TradChinese: 萬, SimpChinese+Japanese: 万
                value -= part * 1_0000;
                firstPart = false;
            }
            if (value > 0)
            {
                sb.Append(firstPart ? null : " ");
                sb.AppendFormat("{0}", value);
            }

            return sb.Length > 0 ? sb.ToString() : "0";
        }
    }
}
