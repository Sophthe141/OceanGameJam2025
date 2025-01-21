using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    //controle do mouse
    private Camera mainCam;
    private Vector3 mousePos;
    //flip de arma
    public SpriteRenderer flipArma;
    private float angArma;
    //indexacao e lista de armas
    public static int selectedWeapon = 0;
    public List<Transform> listOfWeapons = new List<Transform>();

     // Variáveis para controle da taxa de atualização
    private float lastUpdateTime;
    public float updateCooldown = 0.01f; // Ajuste conforme necessário

    // Start is called before the first frame update

    void Start()
    {
        //Obtem transform do objeto mae  
        for (int i = 0; i < transform.childCount; i++)
        {
            // Obtém o transform de cada filho e adiciona à lista
            listOfWeapons.Add(transform.GetChild(i));
        }
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        SelectWeapon();
    }

    void onEnable()
    {
        SelectWeapon();
    }


    // Update is called once per frame
    void Update()
    {
        //rotação
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);


        //flipscprite
        flipRenderer(rotZ);

        //Seleciona arma  
         // Obtém o delta do scroll do mouse
        float scrollDelta = Input.mouseScrollDelta.y;
        // Atualiza a seleção da arma com um cooldown
        if (Time.time - lastUpdateTime >= updateCooldown && scrollDelta != 0)
 {
            // Atualiza o índice da arma selecionada com base na direção do scroll
            int previousSelectedWeapon = selectedWeapon;
            selectedWeapon += (int)Mathf.Sign(scrollDelta);

            // Garante que a seleção da arma permaneça dentro dos limites válidos
            selectedWeapon = Mathf.Clamp(selectedWeapon, 0, transform.childCount - 1);
            
            // Chama a função SelectWeapon apenas quando a seleção muda
            if (previousSelectedWeapon != selectedWeapon)
            {
                //print("SelectedWeapon 1 " + selectedWeapon);
                SelectWeapon();
            }else if((int)Mathf.Sign(scrollDelta) > 0){
                selectedWeapon += (int)Mathf.Sign(scrollDelta) - 2;
                //print("SelectedWeapon 2 " + selectedWeapon);
                SelectWeapon(); 
            }else if((int)Mathf.Sign(scrollDelta) < 0){
                selectedWeapon += (int)Mathf.Sign(scrollDelta) + 2;
                //print("SelectedWeapon 3 " + selectedWeapon);
                SelectWeapon(); 
            }
            lastUpdateTime = Time.time;
        }

    }
//flipa o sprite renderer da arma da vez com base na rotação do mouse(valor recebid opor parametro)
void flipRenderer(float rotZ){
        angArma = rotZ;
        //print("Angulo =" + angArma);
        if(angArma <= 90 && angArma >= -90){
            flipArma.flipY = false;
        }else if(angArma > 90 && angArma <= 100){
            flipArma.flipY = true;
        }else if(angArma >= -100 && angArma < -90){
            flipArma.flipY = true;
        }
}

void SelectWeapon()
    {
        for (int i = 0; i < listOfWeapons.Count; i++)
        {
            bool isActive = (i == selectedWeapon);
            listOfWeapons[i].gameObject.SetActive(isActive);
            if(isActive)
            flipArma = listOfWeapons[i].gameObject.GetComponent<SpriteRenderer>();
            
        }
    }
}