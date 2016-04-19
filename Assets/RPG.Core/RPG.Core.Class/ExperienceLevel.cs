using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class ExperienceLevel
    {
        public int nivel;
        public float modify;

        public double nivelExperience;
        public double nextExperience;
        public double currentExperience;
        public double lastExperience;
        public double totalExperience;

        public LevelPoints levelPoints;

        public ExperienceLevel()
        {
            this.nivel = 0;
            this.modify = 0F;
            this.currentExperience = 0;
            this.nivelExperience = 0;
            this.nextExperience = 0;
            this.lastExperience = 0;
            this.totalExperience = 0;
            this.levelPoints = new LevelPoints();
        }
        public ExperienceLevel(ExperienceLevel _experienceLevel)
        {
            this.nivel = _experienceLevel.nivel;
            this.modify = _experienceLevel.modify;
            this.currentExperience = _experienceLevel.currentExperience;
            this.nivelExperience = _experienceLevel.nivelExperience;
            this.nextExperience = _experienceLevel.nextExperience;
            this.lastExperience = _experienceLevel.lastExperience;
            this.totalExperience = _experienceLevel.totalExperience;
            this.levelPoints = new LevelPoints(_experienceLevel.levelPoints);
        }
        public void baseExperienceLevel()
        {
            this.nivel = 1;
            this.modify = 1.2F;
            this.currentExperience = 0;
            this.nivelExperience = 150;
            this.nextExperience = nivelExperience;
            this.lastExperience = 0;
            this.totalExperience = 0;
            this.levelPoints.levelByPoints = 1;
        }
        public void baseExperienceLevel(float _modify, double _nextExperience, int _levelByPoints)
        {
            this.nivel = 1;
            this.modify = _modify;
            this.nextExperience = _nextExperience;
            this.levelPoints.levelByPoints = _levelByPoints;
        }
        public void addExperience(double _experience, Class _class, Attributes _attributes)
        {
            this.currentExperience += _experience;
            this.assingLevel(_class, _attributes);
        }
        public void addExperience(double _experience)
        {
            this.currentExperience += _experience;
            this.assingLevel(new Class(), new Attributes());
        }
        void assingLevel(Class _class, Attributes _attributes)
        {
            this.totalExperience += this.currentExperience;

            while (this.currentExperience > this.nextExperience)
            {
                if (this.currentExperience >= this.nextExperience)
                {
                    this.nivel++;
                    this.levelPoints.assingPoints();
                    this.currentExperience -= this.nextExperience;
                    this.lastExperience = this.nextExperience;
                    this.nextExperience *= this.modify;
                    if (_class.typeClass != _Class.None) _attributes.attributePerLevel(_class);
                }
            }
        }
    }
}
