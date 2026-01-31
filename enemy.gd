extends CharacterBody2D
var speed = 200.0
@onready var target= $"../CharacterBody2D"
func _physics_process(_delta: float) -> void:
	if is_instance_valid(target):
		var direction = (target.position - position).normalized()
		velocity = direction * speed
		look_at(target.position)
		move_and_slide()
	else:
		velocity = Vector2.ZERO
