#version 330 core
layout (location=0) in vec3 aPos;
layout (location=1) in vec3 aNormal;
layout (location=2) in vec2 aTexCoords;

//计算世界空间坐标
out vec3 Position;
//法向量
out vec3 Normal;
//纹理
out vec2 TexCoords;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main(){
	
	Position = vec3(model*vec4(aPos,1.0));//世界空间坐标
	Normal = mat3(transpose(inverse(model))) * aNormal;//自己生成法线矩阵

	gl_Position = projection * view * vec4(Position,1.0);
	TexCoords = aTexCoords;//纹理
}