#version 330 core
out vec4 FragColor;

in vec3 Position;//����ռ�����
in vec3 Normal;//������
in vec2 TexCoords;

uniform vec3 cameraPos;//���λ��
uniform samplerCube skybox;//������ͼ

uniform sampler2D texture_specular1;
uniform sampler2D texture_diffuse1;

//���ﲻ��Ҫ��Դ
void main(){    
    //��һ������
    vec3 norm = normalize(Normal);//��������׼��
    vec3 viewDir = normalize(Position - cameraPos);//���߷���
    float ratio = 1.00 / 1.52;//�����
    //vec3 R = reflect(viewDir, norm);//��������
    vec3 R = refract(viewDir, norm,ratio);//��������

    FragColor = vec4(texture(skybox, R).rgb, 1.0);//��R����պ��ϲ���

}

