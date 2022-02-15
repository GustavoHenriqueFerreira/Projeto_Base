import axios from "axios";

export const LerConteudoDaImagem = async (formData) => {
    let resultado;

    await axios({
        method: "POST",
        url: "https://senai-ocr.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data: formData,
        headers: {
            "Content-Type": "multipart/form-data",
            "Ocp-Apim-Subscription-Key": "9d716f060b4c4215a212a0fba254e9b9"
        }
    }).then(response => {
        resultado = lerJSON(response.data);
    })
        .catch(erro => console.log(erro))

    return resultado;
}

export const lerJSON = (objeto) => {

    let resultado;

    objeto.regions.forEach(regions => {
        regions.lines.forEach(lines => {
            lines.words.forEach(words => {
                if (words.text[0] === "1" && words.text[1] === "2") {
                    resultado = words.text;
                }
            });
        });
    });

    return resultado;
}