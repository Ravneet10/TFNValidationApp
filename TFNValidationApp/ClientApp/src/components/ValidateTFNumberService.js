
export function validateTFN(currentRef, tfnNumber) {
    fetch('TfnValidate', {
        method: 'POST',
        headers: {
            'Accept': 'application/json, text/plain, */*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            tfnNumber: tfnNumber.replace(/\s+/g, '')
        })
    }).then(res => {
        if (!res.ok) {
            res.json().then(function (data) {
                currentRef.setErrorResponseState(data);
            });
            throw new Error(res.errors)
        }
        else if (res) {
            res.json().then(function (data) {
                currentRef.setResponseState(data);
            });
        }
    })
        .catch(function (error) {
            console.log(error);
        });
}