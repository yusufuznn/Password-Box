console.log("version.js yüklendi ve çalışıyor");

document.addEventListener("DOMContentLoaded", function () {
    fetch("/version")
        .then(response => {
            if (!response.ok) throw new Error("HTTP status " + response.status);
            return response.json();
        })
        .then(data => {
            document.getElementById("versionText").textContent = data.version || "Versiyon bilgisi yok";
        })
        .catch(err => {
            console.error("Fetch error:", err);
            document.getElementById("versionText").textContent = "Versiyon bilgisi alınamadı";
        });
});