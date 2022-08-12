export function enableDragDrop(componentInstance) {
    const containers = document.querySelectorAll('.task-list-container');
    if (containers.length === 0) return;
    const droppable = new Draggable.Droppable(containers, {
        draggable: '.draggable',
        dropzone: '.cards',
        delay: 0,
        distance: 50,
        mirror: { constrainDimensions: true }
    });
    droppable.on('droppable:stop', async evt => {
        console.log(evt.data);
        if (componentInstance) {
            const data = evt.data;
            const taskCardId = parseInt(data.dragEvent.data.source.dataset.taskCardId);
            const taskListId = parseInt(data.dropzone.dataset.taskListId);
            await componentInstance.invokeMethodAsync(
                'HandleTaskCardMove', taskCardId, taskListId);
        } else {
            // There's no component instance. This is an error.
            throw new Error('Cannot notify component, because no component was supplied');
        }
    });
}