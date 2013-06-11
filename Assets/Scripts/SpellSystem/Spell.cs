using UnityEngine;

public abstract class Spell {
	
	// Name of the spell; e.g. Fire Bolt
	string name { get; set; }
	
	// The effect that will be run for the spell; a particle effect for example
	GameObject effect { get; set; }
	
	// Distance at which it can be cast
	// - a self buff would have no range requirements;
	// - a fire bolt would have a certain range (30 yards for example);
	float castRange { get; set; }
	
	// Does it requires a target (a bolt requires a target, a self buff or frontal/local aoe wouldn't)
	bool requiresTarget { get; set; }
	
	// Cast duration - how long it takes for the actual casting to complete (0 means instant; 2.5 means 2.5 seconds; etc)
	float castDuration { get; set; }
	
	// Whether the spell requires line of sight or not to take affect
	bool lineOfSight { get; set; }
	
	// The base cooldown of the spell if it has any
	float baseCoolDownTime { get; set; }
	
	// The time remaining until spell is off cooldown
	float coolDownTimer { get; set; }
		
	// Base global cooldown; 
	int baseGlobalCooldown = 1;
	
	// On Cooldown ? Flag set whether the 
	bool isOnCoolDown { get; set; }
	
	// Performs the actual casting
	public abstract void castSpell();
}
