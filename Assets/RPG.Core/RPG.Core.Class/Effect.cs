using System;
using System.Collections.Generic;
using RPG.Lite.RPGCustom;

namespace RPG.Lite
{
    [System.Serializable]
    public class Effect
    {
        [System.Serializable]
        public class StatesEffect
        {

            public _Condition condition;                // Condição que pode causar o estado do efeito
            public _EffectsRemove effectsRemove;        // Qual efeitos esse buff irá remover ou atribuir   
            public int reservedValue;                   // VVáriavel onde vai armazenar o Valor tirado ou atribuido
            public int value;                           // Valor do efeito que será removido ou atribuido
            public float cooldownEffects;               // tempo para remoção da condição ou atributo duranto o "cooldown" total
            public bool instante;                       // Se é um efeito que é instantaneo ou é gradadivo

            /// <summary>
            /// Variaveis para controle do efeito caso ele sejá "instante"
            /// </summary>

            float c_cooldownEffects;                    // Tempo auxiliar para cada remoção ou atribuição do efeito quando ele é "instante"
            bool c_instante = true;                     // Variavel auxiliar para controle do instante.     

            /// <summary>
            /// Construtor sem paremetro dos estados dos efeitos
            /// </summary>
            public StatesEffect()
            {
                this.condition = _Condition.None;
                this.effectsRemove = _EffectsRemove.None;
                this.reservedValue = 0;
                this.value = 0;
                this.cooldownEffects = 0f;
                this.c_cooldownEffects = 0f;
                this.instante = false;
            }
            /// <summary>
            /// Construtor com parametro dos estados dos efeitos
            /// </summary>
            /// <param name="_effect"></param>
            public StatesEffect(StatesEffect _effect)
            {
                this.condition = _effect.condition;
                this.effectsRemove = _effect.effectsRemove;
                this.reservedValue = _effect.reservedValue;
                this.value = _effect.value;
                this.cooldownEffects = _effect.cooldownEffects;
                this.c_cooldownEffects = 0f;
                this.instante = _effect.instante;
            }
            /// <summary>
            /// Método de sobrecarga para reverter os valores dos Atributos
            /// </summary>
            /// <param name="_attributes"></param>
            public void restoreValue(Attributes _attributes)
            {
                _attributes.reverseEffects(effectsRemove, reservedValue);
            }
            /// <summary>
            /// Método de sobrecarga para reverter os valores do Damage
            /// </summary>
            /// <param name="_damage"></param>
            public void restoreValue(Damage _damage)
            {
                _damage.reverseEffects(effectsRemove, reservedValue);
            }
            /// <summary>
            /// Método de sobrecarga para reverter os valores do Armor
            /// </summary>
            /// <param name="_armor"></param>
            public void restoreValue(Armor _armor)
            {
                _armor.reverseEffects(effectsRemove, reservedValue);
            }
            /// <summary>
            /// Método Update Do Atributo, responsavél por remover ou atribuiir efeitos dos Atributos
            /// </summary>
            /// <param name="_attributes"></param>
            /// <param name="deltaTime"></param>
            public void update(Attributes _attributes, float deltaTime)
            {
                if(!instante)
                {
                    if(c_cooldownEffects >= cooldownEffects)
                    {
                        this.c_cooldownEffects = 0f;
                        _attributes.removeEffects(effectsRemove, value);
                        this.reservedValue += value;
                    }
                    c_cooldownEffects += deltaTime;
                }
                else
                {
                    if (c_instante)
                    {
                        _attributes.removeEffects(effectsRemove, value);
                        this.reservedValue += value;
                        c_instante = false;
                    }
                }
            }
            /// <summary>
            /// Método Update Do Damage, responsavél por remover ou atribuiir efeitos do Damage
            /// </summary>
            /// <param name="_damage"></param>
            /// <param name="deltaTime"></param>
            public void update(Damage _damage, float deltaTime)
            {
                if (!instante)
                {
                    if (c_cooldownEffects >= cooldownEffects)
                    {
                        this.c_cooldownEffects = 0f;
                        _damage.removeEffects(effectsRemove, value);
                        this.reservedValue += value;
                    }
                    c_cooldownEffects += deltaTime;
                }
                else
                {
                    if (c_instante)
                    {
                        _damage.removeEffects(effectsRemove, value);
                        this.reservedValue += value;
                        c_instante = false;
                    }
                }
            }
            /// <summary>
            /// Método Update Do Armor, responsavél por remover ou atribuir efeitos do Armor
            /// </summary>
            /// <param name="_armor"></param>
            /// <param name="deltaTime"></param>
            public void update(Armor _armor, float deltaTime)
            {
                if (!instante)
                {
                    if (c_cooldownEffects >= cooldownEffects)
                    {
                        this.c_cooldownEffects = 0f;
                        _armor.removeEffects(effectsRemove, value);
                        this.reservedValue += value;
                    }
                    c_cooldownEffects += deltaTime;
                }
                else
                {
                    if (c_instante)
                    {
                        _armor.removeEffects(effectsRemove, value);
                        this.reservedValue += value;
                        c_instante = false;
                    }
                }
            }
            /// <summary>
            /// Método Update Do Life, responsavél por remover ou atribuir efeitos do Life
            /// </summary>
            /// <param name="_life"></param>
            /// <param name="deltaTime"></param>
            public void update(Life _life, float deltaTime)
            {
                if (!instante)
                {
                    if (c_cooldownEffects >= cooldownEffects)
                    {
                        this.c_cooldownEffects = 0f;
                        _life.removeEffects(effectsRemove, value);
                        this.reservedValue += value;
                    }
                    c_cooldownEffects += deltaTime;
                }
                else
                {
                    if (c_instante)
                    {
                        _life.removeEffects(effectsRemove, value);
                        this.reservedValue += value;
                        c_instante = false;
                    }
                }
            }
        }

        public string name;                         // Nome do efeito
        public string desc;                         // descrição do efeito
        public string pathImage;                    // Caminho da Imagens que pode ser o icone para representar o efeito
        public List<StatesEffect> effects;          // Lista dos buff e debuffs dos efeitos
        public int possibility;                     // Possibilidade de conseguir atribuir o efeito
        public float cooldown;                      // tempo de duração do efeito

        public float c_cooldown;                    // Tempo atual do efeito

        /// <summary>
        /// Construtor sem parametro do efeito
        /// </summary>
        public Effect()
        {
            this.name = "EffectUnknown";
            this.desc = "EffectUnknown Desc";
            this.pathImage = "";
            this.effects = new List<StatesEffect>();
            this.possibility = 0;
            this.cooldown = 0f;
            this.c_cooldown = 0f;
        }
        /// <summary>
        /// Construtor com Parametro do efeito
        /// </summary>
        /// <param name="_effect"></param>
        public Effect( Effect _effect )
        {
            this.name = _effect.name;
            this.desc = _effect.desc;
            this.pathImage = _effect.pathImage;
            this.effects = _effect.effects;
            this.cooldown = _effect.cooldown;
            this.possibility = _effect.possibility;
            this.c_cooldown = 0;
        }
        /// <summary>
        /// Método Update responsavél pelos updates de todos os ciclos dos efeitos, atribuindo seus valores a cada componente.
        /// </summary>
        /// <param name="_attributes"></param>
        /// <param name="_damage"></param>
        /// <param name="_armor"></param>
        /// <param name="_life"></param>
        /// <param name="deltaTime"></param>
        public void update(Attributes _attributes, Damage _damage, Armor _armor, Life _life, float deltaTime)
        {
            this.c_cooldown += deltaTime;

            if (this.c_cooldown < this.cooldown)
            {
                for (int i = 0; i < effects.Count; i++)
                {
                    _EffectsRemove __effect = this.effects[i].effectsRemove;

                    if( __effect == _EffectsRemove.Strength ||
                        __effect == _EffectsRemove.Agility ||
                        __effect == _EffectsRemove.Stamina ||
                        __effect == _EffectsRemove.Intelligence)
                    {
                        this.effects[i].update(_attributes, deltaTime);
                    }
                    else if (   __effect == _EffectsRemove.Dark ||
                                __effect == _EffectsRemove.Fire ||
                                __effect == _EffectsRemove.Frost ||
                                __effect == _EffectsRemove.Nature ||
                                __effect == _EffectsRemove.Armor ||
                                __effect == _EffectsRemove.Parry)
                    {
                        this.effects[i].update(_armor, deltaTime);
                    }
                    else if (   __effect == _EffectsRemove.Damage ||
                                __effect == _EffectsRemove.CriticalDamage ||
                                __effect == _EffectsRemove.ElementalDamage)
                    {
                        this.effects[i].update(_damage, deltaTime);
                    }
                    else if (__effect == _EffectsRemove.Life)
                    {
                        this.effects[i].update(_life, deltaTime);
                    }
                }
            }
            else
            {
                for (int i = 0; i < effects.Count; i++)
                {
                    _EffectsRemove __effect = this.effects[i].effectsRemove;

                    if (__effect == _EffectsRemove.Strength ||
                        __effect == _EffectsRemove.Agility ||
                        __effect == _EffectsRemove.Stamina ||
                        __effect == _EffectsRemove.Intelligence)
                    {
                        this.effects[i].restoreValue(_attributes);
                    }
                    else if (__effect == _EffectsRemove.Dark ||
                                __effect == _EffectsRemove.Fire ||
                                __effect == _EffectsRemove.Frost ||
                                __effect == _EffectsRemove.Nature ||
                                __effect == _EffectsRemove.Armor ||
                                __effect == _EffectsRemove.Parry)
                    {
                        this.effects[i].restoreValue(_armor);
                    }
                    else if (__effect == _EffectsRemove.Damage ||
                                __effect == _EffectsRemove.CriticalDamage ||
                                __effect == _EffectsRemove.ElementalDamage)
                    {
                        this.effects[i].restoreValue(_damage);
                    }
                }
            }
        }
        /// <summary>
        /// Método Update responsavél pelos updates de todos os ciclos dos efeitos, atribuindo seus valores a cada componente.
        /// Usa como parametro O CustomCharacter que é nativo da biblioteca
        /// </summary>
        /// <param name="_character"></param>
        /// <param name="deltaTime"></param>
        public void update(RPGCustomCharacter _character, float deltaTime)
        {
            this.c_cooldown += deltaTime;

            if (this.c_cooldown < this.cooldown)
            {
                for (int i = 0; i < effects.Count; i++)
                {
                    _EffectsRemove __effect = this.effects[i].effectsRemove;

                    if (__effect == _EffectsRemove.Strength ||
                        __effect == _EffectsRemove.Agility ||
                        __effect == _EffectsRemove.Stamina ||
                        __effect == _EffectsRemove.Intelligence)
                    {
                        this.effects[i].update(_character.attributes, deltaTime);
                    }
                    else if (__effect == _EffectsRemove.Dark ||
                                __effect == _EffectsRemove.Fire ||
                                __effect == _EffectsRemove.Frost ||
                                __effect == _EffectsRemove.Nature ||
                                __effect == _EffectsRemove.Armor ||
                                __effect == _EffectsRemove.Parry)
                    {
                        this.effects[i].update(_character.armor, deltaTime);
                    }
                    else if (__effect == _EffectsRemove.Damage ||
                                __effect == _EffectsRemove.CriticalDamage ||
                                __effect == _EffectsRemove.ElementalDamage)
                    {
                        this.effects[i].update(_character.damage, deltaTime);
                    }
                    else if (__effect == _EffectsRemove.Life)
                    {
                        this.effects[i].update(_character.life, deltaTime);
                    }
                }
            }
            else
            {
                for (int i = 0; i < effects.Count; i++)
                {
                    _EffectsRemove __effect = this.effects[i].effectsRemove;

                    if (__effect == _EffectsRemove.Strength ||
                        __effect == _EffectsRemove.Agility ||
                        __effect == _EffectsRemove.Stamina ||
                        __effect == _EffectsRemove.Intelligence)
                    {
                        this.effects[i].restoreValue(_character.attributes);
                    }
                    else if (__effect == _EffectsRemove.Dark ||
                                __effect == _EffectsRemove.Fire ||
                                __effect == _EffectsRemove.Frost ||
                                __effect == _EffectsRemove.Nature ||
                                __effect == _EffectsRemove.Armor ||
                                __effect == _EffectsRemove.Parry)
                    {
                        this.effects[i].restoreValue(_character.armor);
                    }
                    else if (__effect == _EffectsRemove.Damage ||
                                __effect == _EffectsRemove.CriticalDamage ||
                                __effect == _EffectsRemove.ElementalDamage)
                    {
                        this.effects[i].restoreValue(_character.damage);
                    }
                }
            }
        }
        /// <summary>
        /// método que verifica se foi possivel atribuir o efeito a este componente
        /// </summary>
        /// <returns></returns>
        public bool putEffect()
        {
            int _number = UnityEngine.Random.Range(0, 100);
            if (_number <= this.possibility)
                return true;
            else
                return false;
        }
        public float get_c_cooldown() { return this.c_cooldown; }
    }
}
