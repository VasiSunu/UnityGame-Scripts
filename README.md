# Unity 2D Game - Script Showcase

Acest repository conține scripturile principale pentru jocul meu 2D realizat în Unity.

**Funcționalități implementate până acum:**
- Sistem de camere multiple cu tranziții și tier-uri de dificultate
- Sistem de combat cu damage, HP (health points) și regenerare
- Sistem de shop cu upgrade-uri și progres (ex; creșterea vieții sau a puterii)
- GameManager global care monitorizează progresul și notifică camerele
- Spawning de inamici în funcție de dificultate

**Structura folderelor:**
- Scripts/GameManager.cs: gestionează progresul global al jocului, monitorizează starea și dificultatea globală, interacționează cu camerele și menține starea generală a jocului.
- Scripts/CameraFollow.cs: gestionează urmărirea jucătorului de către cameră, ajustându-se pe măsură ce acesta se mișcă între camerele din joc.
- Scripts/Shop/ShopSlot.cs: gestionează fiecare slot din magazin, controlând interacțiunile cu jucătorul pentru achiziționarea de upgrade-uri, afișarea prețului și a descrierii itemelor.
- Scripts/Shop/ShopItem.cs: reprezintă fiecare obiect din magazin (ex: viață, damage, etc.), conținând informații despre preț și efectele aplicate asupra jucătorului la achiziționare.
- Scripts/Shop/HealthRegenItem.cs: un tip specific de ShopItem care oferă regenerare de viață atunci când este cumpărat.
- Scripts/Room/RoomMove.cs: controlează tranzacțiile între camere, permite jucătorului să se miște între locații în cadrul jocului.
- Scripts/Room/RoomController.cs: gestionează logica fiecarei camere, inclusiv spawn-ul inamicilor și obiectelor, precum și determinarea dificultății în funcție de progresul jucătorului.
- Scripts/Player/PlayerStats.cs: controlează statistici vitale ale jucătorului, de exemplu viața, puterea, distanța de atac și modificările acestora pe măsură ce jocul progresează.
- Scripts/Player/PlayerMovement.cs: gestionează mișcarea jucătorului pe harta jocului, inclusiv detalii despre viteza de mișcare.
- Scripts/Player/PlayerCombat.cs: controlează atacurile jucătorului, calculând damage-ul și aplicându-l inamicilor.
- Scripts/Player/HealthBarPlayer.cs: gestionează bara de viață vizibilă a jucătorului pe ecran, actualizându-se pe măsură ce playerul suferă daune.
- Scripts/Player/PlayerAnimator.cs: gestionează animațiile jucătorului.
- Scripts/Enemy/FloatingHealthBar.cs: gestionează afișarea barei de sănătate plutitoare pentru inamici, actualizându-se în funcție de daunele primite.
- Scripts/Enemy/EnemySpawner.cs: gestionează spawn-ul inamicilor în diferite camere.
- Scripts/Enemy/EnemyFollow.cs: controlează comportamentul inamicilor care urmăresc jucătorul în timpul jocului.
- Scripts/Enemy/EnemyPatrol.cs: gestionează inamicii care patrulează între anumite puncte din cameră.
- Scripts/Enemy/EnemyCombat.cs: gestionează comportamentele de atac ale inamicilor, daunele pe care aceștia le pot aplica jucătorului.
- Scripts/Enemy/EnemyAnimator.cs: controlează animațiile inamicilor, precum atacuri și mișcări.
- Scripts/Collectible/ResourceCounter.cs: controlează colectarea de resurse de către jucător.
- Scripts/Collectible/CollectibleLife.cs: gestionează obiectele care oferă viață suplimentară jucătorului atunci când sunt colectate.
- Scripts/Collectible/Collectible.cs: reprezintă obiectele colectibile din joc (resursele), gestionând interacțiunile acestora cu jucătorul.

Toate scripturile sunt comentate și modularizate pentru ușurință în citire și înțelegere.
