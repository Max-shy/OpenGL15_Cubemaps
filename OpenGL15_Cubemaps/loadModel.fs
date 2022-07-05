#version 330 core
out vec4 FragColor;

in vec3 Position;//世界空间坐标
in vec3 Normal;//法向量
in vec2 TexCoords;

uniform vec3 cameraPos;//相机位置
uniform samplerCube skybox;//环境贴图

uniform sampler2D texture_specular1;
uniform sampler2D texture_diffuse1;

//这里不需要光源
void main(){    
    //归一化向量
    vec3 norm = normalize(Normal);//法向量标准化
    vec3 viewDir = normalize(Position - cameraPos);//视线方向
    float ratio = 1.00 / 1.52;//折射度
    //vec3 R = reflect(viewDir, norm);//反射向量
    vec3 R = refract(viewDir, norm,ratio);//折射向量

    FragColor = vec4(texture(skybox, R).rgb, 1.0);//用R在天空盒上采样

}

