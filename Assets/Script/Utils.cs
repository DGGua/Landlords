using UnityEngine;

static class LocalUtils {
    public static bool RandomHappen(double possibility) {
        return Random.Range(0, 100) >= possibility * 100;
    }
}